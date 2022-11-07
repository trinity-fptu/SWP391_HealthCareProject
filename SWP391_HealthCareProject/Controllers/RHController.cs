﻿using Microsoft.AspNetCore.Mvc;
using SWP391_HealthCareProject.DataAccess;
using SWP391_HealthCareProject.Filters;
using SWP391_HealthCareProject.Models;

namespace SWP391_HealthCareProject.Controllers
{
    [RequestAuthentication]
    public class RHController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetObjectFromJson<User>("User") != null)
            {
                var userInfo = HttpContext.Session.GetObjectFromJson<User>("User");
                string userName = userInfo.UserName;
                ViewBag.UserName = userName;
            }
            return View();
        }

        public IActionResult ManagePost()
        {
            var hrAdminInfo = HttpContext.Session.GetObjectFromJson<HospitalRedCrossAdmin>("HRAdmin");
            List<Post> posts = PostDAO.GetPostsByRHaid(hrAdminInfo.Rhaid);
            return View(posts);
        }

        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadPost(Post post, IFormFile postImage)
        {
            var userInfo = HttpContext.Session.GetObjectFromJson<User>("User");
            HospitalRedCrossAdmin hrAd = HospitalRedCrossAdminDAO.GetHRAdrByUserId(userInfo.UserId);
            post.Rhaid = hrAd.Rhaid;
            // Save uploaded image.
            string path = @"wwwroot\assets\postImg";
            Post? lastPost = PostDAO.GetLastRecord();
            string savedName = $"PostPic{1}";
            if (lastPost != null)
            {
                savedName = $"PostPic{lastPost.PostId + 1}";
            }         
            string uploadFilepath = postImage.SaveUploadedFile(path, savedName);
            // Set filepath for Img attribute.
            post.Img = uploadFilepath;
            // Add post.
            PostDAO.AddPost(post);
            return RedirectToAction("ManagePost");
        }
        public IActionResult DeletePost(int postId)
        {
            PostDAO.DeletePostById(postId);
            return RedirectToAction("ManagePost");
        }

        public IActionResult ManageCampaign()
        {
            return View();
        }

        public IActionResult CreateCampaign()
        {
            return View();
        }

        public IActionResult ManagePlan()
        {
            return View();
        }

        public IActionResult CreatePlan()
        {
            return View();
        }

        public IActionResult ManageVolunteer()
        {
            return View();
        }
    }
}