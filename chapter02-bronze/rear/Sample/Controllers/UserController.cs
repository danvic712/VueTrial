//-----------------------------------------------------------------------
// <copyright file= "UserController.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/7/6 17:48:29
// Modified by:
// Description: 用户管理 API 接口控制器
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using Sample.Models;
using Sample.Services.User;
using System.Collections.Generic;

namespace Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Initialize

        /// <summary>
        /// 功能接口
        /// </summary>
        private readonly IUserService _user;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="user">接口实例</param>
        public UserController(IUserService user)
        {
            _user = user;
        }

        #endregion Initialize

        #region APIs

        /// <summary>
        /// 获取所有的用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<UserViewModel> Get()
        {
            return _user.GetUsers();
        }

        /// <summary>
        /// 根据用户信息搜索用户
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <param name="name">姓名</param>
        /// <param name="email">电子邮箱</param>
        /// <returns></returns>
        [HttpGet("query")]
        public IEnumerable<UserViewModel> Get(string id, string name, string email)
        {
            var data = _user.GetUsers(id, name, email);
            return data;
        }

        /// <summary>
        /// 新增用户信息
        /// </summary>
        /// <param name="viewModel">用户视图模型</param>
        /// <returns></returns>
        [HttpPost]
        public void Post([FromBody] UserViewModel viewModel)
        {
            _user.SaveUserInfo(viewModel);
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <param name="viewModel">用户视图模型</param>
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] UserViewModel viewModel)
        {
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="id">用户编号</param>
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
        }

        #endregion APIs
    }
}