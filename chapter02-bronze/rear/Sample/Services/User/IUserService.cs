//-----------------------------------------------------------------------
// <copyright file= "IUserService.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/7/6 18:03:22
// Modified by:
// Description: 用户管理功能接口
//-----------------------------------------------------------------------
using Sample.Models;
using System.Collections.Generic;

namespace Sample.Services.User
{
    public interface IUserService
    {
        #region Services

        /// <summary>
        /// 获取所有的用户信息
        /// </summary>
        /// <returns></returns>
        IList<UserViewModel> GetUsers();

        /// <summary>
        /// 根据用户信息搜索用户
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <param name="name">姓名</param>
        /// <param name="email">电子邮箱</param>
        /// <returns></returns>
        IList<UserViewModel> GetUsers(string id, string name, string email);

        /// <summary>
        /// 新增用户信息
        /// </summary>
        /// <param name="viewModel">用户视图模型</param>
        /// <returns></returns>
        bool SaveUserInfo(UserViewModel viewModel);

        #endregion Services
    }
}