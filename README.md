# FANEW — 企业级综合管理系统

ASP.NET MVC 企业内部管理系统，涵盖组织管理、工作流、知识库、公告通知、邮件、办公等核心模块。

## 目录结构

```
FANEW/
├── FA.sln                  # Visual Studio 解决方案
├── Model/                  # 数据模型层（实体类，对应数据库表）
├── DAL/                    # 数据访问层（SQL/LINQ 操作）
├── BLL/                    # 业务逻辑层（含 IBLL/ 接口定义）
├── Service/                # 服务层（WCF/WebAPI 对外接口）
├── Utility/                # 公共工具类库（加密、日志、缓存等）
├── Web/                    # ASP.NET MVC Web 项目（表现层）
│   ├── Web.csproj
│   ├── packages.config     # NuGet 依赖清单
│   ├── Web.config          # 本地运行配置（含数据库连接，不提交真实凭据）
│   └── Web.config.example  # 配置模板（可安全提交，含占位符）
└── DLL/                    # 无法通过 NuGet 获取的私有/专有第三方库
```

## 依赖管理

本项目使用 **NuGet** 管理可公开获取的第三方依赖，依赖清单见 `Web/packages.config`。

### NuGet 管理的主要包

| 包 | 版本 | 说明 |
|---|---|---|
| Microsoft.AspNet.Mvc | 4.0.20505.0 | ASP.NET MVC 框架 |
| Microsoft.AspNet.WebApi.* | 4.0.20505.0 | Web API 框架 |
| Microsoft.AspNet.WebPages | 2.0.20505.0 | Razor 视图引擎 |
| Newtonsoft.Json | 4.5.1 | JSON 序列化 |
| log4net | 1.2.11 | 日志框架 |
| Common.Logging | 1.2.0 | 日志抽象层 |
| WebGrease | 1.0.0 | CSS/JS 压缩 |

### 保留在 DLL/ 目录的依赖（私有/专有）

以下依赖无法通过 NuGet 公开获取，保留在 `DLL/` 目录并通过项目引用管理：

| 文件 | 原因 |
|---|---|
| `Anchor.FA.Inventory.Model.dll` | 内部私有程序集 |
| `Anchor120V7.InnerComm.dll` | 内部私有通信库 |
| `AjaxControlToolkit.dll` | 特定版本 UI 组件，升级风险高 |
| `CKEditor.NET.dll` / `CKFinder.dll` | 富文本编辑器，版本绑定 |
| `Infragistics3.Excel.v9.1.dll` | 商业 Excel 组件（Infragistics 授权） |
| `Microsoft.ReportViewer.*.dll` | Microsoft 报表组件（非 NuGet 版本） |
| `Microsoft.SqlServer.Types.dll` | SQL Server 空间类型，需匹配服务器版本 |
| `MvcCheckBoxList.dll` | 小型 UI 辅助组件 |
| `Spring.Core.dll` | Spring.NET IoC 容器（旧版本，升级风险高） |

## 本地配置

### 1. 配置数据库连接

```bash
# 复制配置模板
cp Web/Web.config.example Web/Web.config
```

编辑 `Web/Web.config`，将 `connectionStrings` 节中的占位符替换为实际值：

```xml
<add name="ConnectionString"
     connectionString="user id=YOUR_DB_USER;pwd=YOUR_DB_PASSWORD;
                       data source=YOUR_SERVER;
                       initial catalog=YOUR_DATABASE;
                       MultipleActiveResultSets=true" />
```

> ⚠️ **安全提示**：`Web/Web.config` 含有数据库凭据，已在 `.gitignore` 中豁免。  
> 请勿将含有真实密码的 `Web.config` 提交到版本控制。

### 2. 还原 NuGet 包

在 Visual Studio 中打开 `FA.sln` 后，NuGet 会自动还原包；或使用命令行：

```bash
nuget restore FA.sln
```

### 3. 构建与运行

使用 Visual Studio 2013/2015（推荐）：
1. 打开 `FA.sln`
2. 设置 `Web` 为启动项目
3. 配置 IIS Express 或本地 IIS（目标框架 .NET 4.0）
4. 按 `F5` 启动

## 技术栈

| 类别 | 技术 |
|---|---|
| 框架 | ASP.NET MVC 4 + WebForms（混合） |
| 语言 | C# (.NET 4.0) |
| 数据库 | SQL Server |
| IoC | Spring.NET |
| 日志 | log4net |
| 报表 | Microsoft ReportViewer |
| 富文本 | CKEditor |
