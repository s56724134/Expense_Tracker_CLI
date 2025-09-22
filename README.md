# 個人記帳系統

一個使用 C# (.NET 8.0) 開發的命令列記帳應用程式，可以追蹤個人支出並提供各種查詢功能。

## 專案連結

🔗 [GitHub Repository](https://github.com/s56724134/Expense_Tracker_CLI)

## 功能特色

- ✅ 新增支出項目
- ✅ 列出所有支出記錄
- ✅ 查看總支出金額
- ✅ 按月份查詢支出統計
- ✅ 刪除指定支出項目
- ✅ 資料自動儲存至 JSON 檔案

## 技術規格

- **語言**: C# (.NET 8.0)
- **架構**: Console Application
- **資料儲存**: JSON 檔案
- **容器化**: Docker 支援

## 快速開始

### 本地執行

```bash
cd app/WeatherConsole
dotnet run
```

### 使用 Docker

```bash
docker-compose up -d
docker exec -it dotnet-dev bash
cd WeatherConsole
dotnet run
```

## 使用方法

執行程式後，輸入以下命令：

- `add` - 新增支出項目
- `list` - 列出所有支出記錄
- `summary` - 顯示總支出金額
- `summarybymonth` - 按月份查詢支出統計
- `delete` - 刪除指定支出項目
- `exit` - 結束程式

### 使用範例

```
請輸入(add、list、summary、summarybymonth、delete、exit):add
請輸入項目:午餐
請輸入金額:120
Expense added successfully (ID: 1)

請輸入(add、list、summary、summarybymonth、delete、exit):list
# ID  Date       Description  Amount
1   2024/09/22  午餐        $120
```

## 專案結構

```
app/
├── WeatherConsole/
│   ├── Program.cs          # 主程式入口
│   ├── Data/
│   │   └── User.cs         # 資料模型
│   ├── Helper/
│   │   ├── UserInput.cs    # 命令解析器
│   │   └── Report.cs       # 資料操作與報表
│   └── Json/
│       └── user.json       # 資料儲存檔案
├── .vscode/                # VS Code 設定
└── WeatherConsole.csproj   # 專案檔案
```

## 開發環境設定

### 前置需求

- .NET 8.0 SDK
- Docker (選用)

### 本地開發

1. Clone 專案
2. 進入專案目錄: `cd app/WeatherConsole`
3. 還原套件: `dotnet restore`
4. 執行程式: `dotnet run`