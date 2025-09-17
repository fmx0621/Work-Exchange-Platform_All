using Job.Models;
using Job.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Job.Areas.Back.Controllers
{
    [Area("Back")]
    public class ApplyController : Controller
    {
        public IActionResult ApplyList(CApplyManagementViewModel vm)
        {
            JobDbContext db = new JobDbContext();
            var query = db.TWorkerApplies.AsQueryable();

            // 關鍵字篩選
            if (!string.IsNullOrEmpty(vm.txtKeyword))
            {
                query = query.Where(p => p.WorkerName.Contains(vm.txtKeyword)
                                        || p.ApplyOwner.Contains(vm.txtKeyword));
            }

            // 業主回覆篩選 (對應 townerAdmission.ReplySituation)
            if (!string.IsNullOrEmpty(vm.ApplyStatus))
            {
                var memberIds = db.TOwnerAdmissions
                                  .Where(o => o.ReplySituation == vm.ApplyStatus)
                                  .Select(o => o.MemberId)
                                  .ToList();

                query = query.Where(w => memberIds.Contains(w.MemberId));
            }

            // 日期範圍
            if (vm.StartDate.HasValue)
            {
                var start = vm.StartDate.Value.Date;
                query = query.Where(p => p.ApplyDate >= start);
            }
            if (vm.EndDate.HasValue)
            {
                var end = vm.EndDate.Value.Date.AddDays(1).AddMilliseconds(-1);
                query = query.Where(p => p.ApplyDate <= end);
            }

            var workerList = query.ToList();

            // 抓對應的 OwnerAdmissions
            var memberIdsAll = workerList.Select(w => w.MemberId).ToList();
            var ownerAdmissions = db.TOwnerAdmissions
                                    .Where(o => memberIdsAll.Contains(o.MemberId))
                                    .ToList();

            // 換宿者回覆篩選
            if (!string.IsNullOrEmpty(vm.WorkerReply))
            {
                workerList = workerList
                    .Where(w => w.ApplySituation == vm.WorkerReply)
                    .ToList();
            }

            // VM 設定
            vm.TworkerApplies = workerList;
            vm.TownerAdmissions = ownerAdmissions;

            // 下拉選單
            ViewBag.StatusList = new SelectList(new List<string> { "待處理", "已接受", "未接受" }, vm.ApplyStatus);
            ViewBag.WorkerReplyList = new SelectList(new List<string> { "待處理", "已錄取", "未錄取" }, vm.WorkerReply);

            return View(vm);
        }


        //-----------------------------------------------------------------------------------------
        [Route("Back/ApplyManagement/[action]/{id?}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("WorkerApply");
            }
            JobDbContext db = new JobDbContext();
            TWorkerApply work = db.TWorkerApplies.FirstOrDefault(p => p.WorkerApplyId == id);
            if (work == null)
            {
                return RedirectToAction("WorkerApply");
            }
            db.TWorkerApplies.Remove(work);
            db.SaveChanges();
            return RedirectToAction("WorkerApply");

        }

        //-----------------------------------------------------------------------------------------
        public IActionResult ApplyDetail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("WorkerApplyList");
            }

            JobDbContext db = new JobDbContext();
            var work = db.TWorkerApplies.FirstOrDefault(p => p.WorkerApplyId == id);

            if (work == null)
            {
                return RedirectToAction("WorkerApplyList");
            }

            var owner = db.TOwnerAdmissions.FirstOrDefault(o => o.MemberId == work.MemberId);

            var vm = new CApplyManagementViewModel
                {
                TworkerApply = work,
                TownerAdmissions = new List<TOwnerAdmission> { owner ?? new TOwnerAdmission()
                }
            };

            return View(vm);
        }

        //-----------------------------------------------------------------------------------------
        public IActionResult MatchingList(CApplyManagementViewModel vm)
        {
            JobDbContext db = new JobDbContext();
            var sql資料 = db.TWorkerApplies.AsQueryable();

            // 關鍵字搜尋
            if (!string.IsNullOrEmpty(vm.txtKeyword))
            {
                sql資料 = sql資料.Where(p => p.WorkerName.Contains(vm.txtKeyword)
                    || p.ApplyOwner.Contains(vm.txtKeyword));
            }

            // 狀態搜尋
            if (!string.IsNullOrEmpty(vm.ApplyStatus))
            {
                sql資料 = sql資料.Where(p => p.ApplySituation == vm.ApplyStatus);
            }

            // 狀態下拉選單
            ViewBag.StatusList = new SelectList(
                new List<string> { "待處理", "未錄取", "已錄取" },
                vm.ApplyStatus
            );

            // 日期區間篩選
            if (vm.StartDate.HasValue)
            {
                var startDate = vm.StartDate.Value.Date;
                sql資料 = sql資料.Where(p => p.ApplyDate >= startDate);
            }

            if (vm.EndDate.HasValue)
            {
                var endDate = vm.EndDate.Value.Date.AddDays(1).AddMilliseconds(-1);
                sql資料 = sql資料.Where(p => p.ApplyDate <= endDate);
            }

            // 查 WorkerApplies
            vm.TworkerApplies = sql資料.ToList() ?? new List<TWorkerApply>();

            // 取出 WorkerId 列表
            var workerIds = vm.TworkerApplies.Any()
                ? vm.TworkerApplies.Select(w => w.MemberId).ToList()
                : new List<int>();

            // 查對應的 OwnerAdmissions
            vm.TownerAdmissions = workerIds.Any()
                ? db.TOwnerAdmissions.Where(o => workerIds.Contains(o.MemberId)).ToList()
                : new List<TOwnerAdmission>();

            // 只保留「換宿者已錄取，且所有業主都已錄取」的資料
            vm.TworkerApplies = vm.TworkerApplies
                .Where(w =>
                {
                    var admissions = vm.TownerAdmissions
                        .Where(o => o.MemberId == w.MemberId)
                        .Select(o => o.ReplySituation)
                        .ToList();

                    // 沒有業主回覆的換宿者也排除
                    return w.ApplySituation == "已錄取" && admissions.Any() && admissions.All(a => a == "已接受");
                })
                .ToList();


            return View(vm);
        }


        //-----------------------------------------------------------------------------------------
        public IActionResult MatchingDetail(int? id)
        {
            if (id == null)
                return RedirectToAction("Pairsuccess");

            JobDbContext db = new JobDbContext();

            // 找單一換宿者，狀態必須已錄取
            var worker = db.TWorkerApplies.FirstOrDefault(w => w.MemberId == id && w.ApplySituation == "已錄取");
            if (worker == null)
                return RedirectToAction("MatchingList");

            // 找對應業主回覆
            var ownerAdmissions = db.TOwnerAdmissions
                .Where(o => o.MemberId == id)
                .ToList();

            // 只保留「所有業主都已錄取」
            if (!ownerAdmissions.Any() || !ownerAdmissions.All(a => a.ReplySituation == "已接受"))
                return RedirectToAction("MatchingList");

            // 建立 ViewModel
            var vm = new CApplyManagementViewModel
            {
                TworkerApplies = new List<TWorkerApply> { worker },
                TownerAdmissions = ownerAdmissions
            };

            return View(vm);
        }



    }
}
