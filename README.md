# TicketSystem
TicketSystem

---

Task1

---
* Phase I

- There are two types of user: QA and RD.
- Only QA can create a bug, edit a bug and delete a bug.
- Only RD can resolve a bug.
- Summary field and Description filed are required of a bug when QA is creating a bug.


追蹤問題項目：主旨、描述及狀態，多設定時間以便後續進行查詢。
角色權限項目：角色控制問題項目可操作形為判定。
問題權限邏輯表參考如下
| Role |新增| 修改 | 刪除 | Reslove |
| -------- | -------- | -------- |-------- |-------- |
| QA     | V     | V     |V     |     |
| RD     |      |      |     |  V   |

**Track Data Model**

| 名稱 | 型別 | 描述 |
| -------- | -------- | -------- |
| *id     | IDENTITY(1,1)     | 追蹤單號     |
| Summary     | varchar(64)     | 主旨     |
| Description    | varchar(512)     | 描述     |
| Reslove     | bit     | 解決狀態(預設為false)     |
| CreateTime     | DateTime     | 建立時間     |
| UpdateTime     | DateTime     | 更新時間     |


**Track Role Data Model**
| 名稱 | 型別 | 描述 |
| -------- | -------- | -------- |
| *id     | IDENTITY(1,1)     | 角色id     |
| Role     | varchar(64)     | 角色     |
| Create     | bit     | 新增     |
| Edit     | bit     | 修改     |
| Delete     | bit     | 刪除     |
| Reslove     | bit     | 更新解決狀態     |


* Phase II
- Adding new field Severity and Priority to a ticket.
- Adding new type of user “PM” that can create new ticket type “Feature Request”. And only RD can mark it as resolved.
- Adding new ticket type “Test Case” that only QA can create and resolve. It’s read-only for other type of users.
- Adding new type of user “Administrator” user that can manage all the stuffs including adding new QA, RD and PM user.

追蹤問題項目：追加了類型、選重等級、優先事項。
角色權限項目：因各個不同角色對應類型而有不同權分，故也同步追加了類型以利區分。
問題權限邏輯表參考如下
| Role | Type |新增| 修改 | 刪除 | Reslove |
| -------- | -------- | -------- | -------- |-------- |-------- |
| QA     |  0:BUG   | V     | V     |V     |     |
| RD     |  0:BUG    |      |      |     |  V   |
| PM     |  1:Feature Request    |   V   |      |     |     |
| RD     |  1:Feature Request    |      |      |     |  V   |
| QA     | 2:Test Case     |   V   |      |     |  V   |


**Track Data Model**

| 名稱 | 型別 | 描述 |
| -------- | -------- | -------- |
| *id     | IDENTITY(1,1)     | 追蹤單號     |
| Type     |   tinyint   | 單號類型0:Bug, 1:Feature Request,2:Test Case    |
| Summary     | varchar(64)     | 主旨     |
| Description    | varchar(512)     | 描述     |
| Severity     | tinyint | 嚴重等級 0:Heigh,1:Medium,2:Low   |
| Priority    | bit     | 優先事項(預設為false)     |
| Reslove     | bit     | 解決狀態(預設為false)     |
| CreateTime     | DateTime     | 建立時間     |
| UpdateTime     | DateTime     | 更新時間     |

**Track Role Data Model**
| 名稱 | 型別 | 描述 |
| -------- | -------- | -------- |
| *id     | IDENTITY(1,1)     | 角色id     |
| Type     |   tinyint   | 單號類型0:Bug, 1:Feature Request,2:Test Case    |
| Role     | varchar(64)     | 角色     |
| Create     | bit     | 新增     |
| Edit     | bit     | 修改     |
| Delete     | bit     | 刪除     |
| Reslove     | bit     | 更新解決狀態     |

新增帳號及管理者對於頁面檢視的權限
AccountList:帳號頁面可管理帳號，僅供有Administrator可查詢此頁面並修改及刪除。
TraceList:追蹤列表可管理問題追蹤

| Role | Funtion | 查詢 | 新增 | 修改 | 刪除 |
| -------- | -------- | -------- | -------- |-------- |-------- |
| Administrator     |  AccountList    |    V  |  V    |  V   |  V   |
| Administrator     |  TraceList    |    V  |  V    |  V   |  V   |
| QA     |   TraceList   |   V   |      |     |     |
| RD     |   TraceList    |   V   |      |     |     |
| PM     |  TraceList     |   V   |      |     |     |


**Account Model**
| 名稱 | 型別 | 描述 |
| -------- | -------- | -------- |
| *id     | IDENTITY(1,1)     | 帳號id     |
| Account     | varchar(64)     | 帳號     |
| Password     | varchar(64)     | 密碼     |
| CreateTime     | DateTime     | 建立時間     |
| UpdateTime     | DateTime     | 更新時間     |

**Account & Role Data Model**
| 名稱 | 型別 | 描述 |
| -------- | -------- | -------- |
| *id     | IDENTITY(1,1)     | 帳號角色id     |
| Account     | varchar(64)     | 帳號     |
| Role     | varchar(64)     | 角色     |
| CreateTime     | DateTime     | 建立時間     |
| UpdateTime     | DateTime     | 更新時間     |

**Role Data Model**
| 名稱 | 型別 | 描述 |
| -------- | -------- | -------- |
| *id     | IDENTITY(1,1)     | 角色id     |
| Role     | varchar(64)     | 角色     |
| Function     |   varchar(64)  |   功能頁面  |
| View     | bit     | 檢視     |
| Create     | bit     | 新增     |
| Edit     | bit     | 修改     |
| Delete     | bit     | 刪除     |

---

Task2

---
