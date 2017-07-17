# 药库管理系统

## 概述
MIMS是一个药库管理系统，它主要有以下功能。
1. 基本信息管理：维护数据库中基本的外键表，保证数据的参照完整性。有入库、出库方式维护、进货单位维护、药品产地维护、药库维护。
2. 药品管理：包括药品字典和药品账册。药品字典包括新增药品条目，删除药品条目，修改药品的基本信息。药品账册包括添加新药品的账目情况，删除失效药品的账目条目和修改现有药品的进货价、零售价和批发价。
3. 进销存管理：分为采购入库、药品入库、药品出库。采购入库包括编辑新的采购计划单和编辑需要采购的药品。药品入库包括编辑入库单和编辑相应供货单位的入库药品。药品出库包括编辑出库单和编辑出库药品信息。
4. 查询管理：包括入库历史查询和出库历史查询。
5. 系统设置：包括数据库连接查、修改密码和查看帮助。

## 相关技术
- 三层架构
- jQuery EasyUI
- SQL Server 2012 + ASP.NET MVC
- Dapper

## 部署
数据库文件在`MIMS/MIMS.Web/App_data`中,附加到sql server2012中，修改web.config中的链接字符串即可。

## 运行界面
![](https://github.com/maoqyhz/MIMS/blob/master/Intro/1.jpg)

![](https://github.com/maoqyhz/MIMS/blob/master/Intro/2.jpg)

![](https://github.com/maoqyhz/MIMS/blob/master/Intro/3.jpg)

![](https://github.com/maoqyhz/MIMS/blob/master/Intro/4.jpg)
