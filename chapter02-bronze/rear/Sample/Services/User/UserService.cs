//-----------------------------------------------------------------------
// <copyright file= "UserService.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/7/6 18:03:37
// Modified by:
// Description: 用户管理功能接口实现
//-----------------------------------------------------------------------
using LinqKit;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Services.User
{
    public class UserService : IUserService
    {
        #region Initialize

        /// <summary>
        /// 数据集合
        /// </summary>
        public static IList<UserModel> Users { get; set; } = new List<UserModel>()
        {
            new UserModel{ Id="20181224113732", Name="zhangsansan",Email = "zhangsansan@qq.com", CreatedTime=DateTime.Parse("2018-12-24 11:37:32")},
            new UserModel{ Id="20190302081211", Name="lisisi",Email = "lisisi@gmail.com", CreatedTime=DateTime.Parse("2019-03-02 08:12:11")},
            new UserModel{ Id="20190707150747", Name="wangwuwu",Email = "wangwuwu@foxmail.com", CreatedTime=DateTime.Parse("2019-07-06 15:07:47")}
        };

        #endregion Initialize

        #region Services

        /// <summary>
        /// 获取所有的用户信息
        /// </summary>
        /// <returns></returns>
        public IList<UserViewModel> GetUsers()
        {
            return Users.OrderByDescending(x => x.CreatedTime).Select(item => new UserViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Email = item.Email,
                CreatedTime = item.CreatedTime.ToString("yyyy-MM-dd HH:mm:ss")
            }).ToList().AsReadOnly();
        }

        /// <summary>
        /// 根据用户信息搜索用户
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <param name="name">姓名</param>
        /// <param name="email">电子邮箱</param>
        /// <returns></returns>
        public IList<UserViewModel> GetUsers(string id, string name, string email)
        {
            IQueryable<UserModel> data = Users.AsQueryable();

            var predicate = PredicateBuilder.New<UserModel>(true);

            // 用户工号
            if (!string.IsNullOrEmpty(id))
            {
                predicate = predicate.And(i => i.Id.Contains(id));
            }

            // 用户姓名
            if (!string.IsNullOrEmpty(name))
            {
                predicate = predicate.And(i => i.Name.Contains(name));
            }

            // 用户电子邮箱
            if (!string.IsNullOrEmpty(email))
            {
                predicate = predicate.And(i => i.Email.Contains(email));
            }

            return data.AsExpandable().Where(predicate).OrderByDescending(x => x.CreatedTime).Select(item => new UserViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Email = item.Email,
                CreatedTime = item.CreatedTime.ToString("yyyy-MM-dd HH:mm:ss")
            }).ToList().AsReadOnly();
        }

        /// <summary>
        /// 新增用户信息
        /// </summary>
        /// <param name="viewModel">用户视图模型</param>
        /// <returns></returns>
        public bool SaveUserInfo(UserViewModel viewModel)
        {
            DateTime date = DateTime.Now;

            var user = new UserModel
            {
                Id = date.ToString("yyyyMMddHHmmss"),
                Name = viewModel.Name,
                Email = viewModel.Email,
                CreatedTime = date
            };
            Users.Add(user);
            return true;
        }

        #endregion Services
    }
}