## Vue.js是什么
+ Vue (读音 /vjuː/，类似于 view) 是一套用于构建用户界面的**渐进式框架**，只关注于视图层。
+ 渐进式框架：Vue包含了现代前端框架所必须的内容，但是你并不需要一开始就把所有的东西都用上，这些都是可选的。
    - 对于Vue的一些解释，推荐简书上的一篇文章，文章地址：[一句话理解Vue核心内容](https://www.jianshu.com/p/a4339bad5256 "一句话理解Vue核心内容")

## 使用Vue.js后与传统的前端开发模式有何不同
+ 在传统的前端开发中，为了完成某个任务，我们需要使用 JS/Jquery 获取到元素的DOM元素，随后对获取到的DOM元素进行操作。而当我们使用Vue进行前端开发后，对于DOM的所有操作全部交由Vue来处理，我们只需要关注于业务代码的实现就可以了。

## 如何使用Vue.js
+ 直接使用 script 标签引入

     `<script  src="https://cdn.jsdelivr.net/npm/vue@2.5.17/dist/vue.js"></script>`
     
     PS：这里可以在Vue的官网上下载好js文件后使用标签引入，也可以使用cdn的形式引入。
+ 使用 Vue-Cli 构建单页应用
    ```
    //1、全局安装Vue-Cli
    npm install -g vue-cli
    //2、进入创建项目目录下
    //3、创建使用webpack模板的Vue单页应用，Enter后根据提示完成项目的创建
    vue init webpack projectname
    //4、进入项目目录下
    //5、下载项目引用的包
    npm install
    //6、运行项目
    npm run dev
    ```

## MVC与MVVM
+ MVC：Model-View-Controller</br>
    MVC是一种表现模式（UI / Presentation Pattern），它将软件的UI部分的设计拆分成三个主要单元，分别是Model、View和Controller</br>
    MVC核心是控制器，它负责处理浏览器传送过来的所有请求，并决定要将什么内容响应给浏览器</br>
    Model：模型，用于存储数据的组件</br>
    View：视图，根据Model数据进行内容展示的组件</br>
    Controller：控制器，接受并处理用户指令，并返回内容</br>

+ MVVM：Model-View-ViewModel</br>
    MVVM的核心是ViewModel，它提供了对于Model和ViewModel的双向数据绑定，通过ViewModel连接View和Model,确保视图与数据的一致性,而这个过程是框架自动完成的,无需手动干预。
    ![MVVM中各模块间联系](https://i.imgur.com/EwnZ4lJ.png)
    
    由Ugaya40 - 自己的作品，CC BY-SA 3.0，https://commons.wikimedia.org/w/index.php?curid=19056842
