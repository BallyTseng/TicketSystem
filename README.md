# TicketSystem
TicketSystem

---

# Task1

---
* Phase I

- There are two types of user: QA and RD.
- Only QA can create a bug, edit a bug and delete a bug.
- Only RD can resolve a bug.
- Summary field and Description filed are required of a bug when QA is creating a bug.

權限關係圖如下
| Role |新增| 修改 | 刪除 | 更新解決狀態 |
| -------- | -------- | -------- |-------- |-------- |
| QA     | V     | V     |V     |     |
| RD     |      |      |     |  V   |

bug 項目資訊

| 名稱 | 描述 |
| -------- |  -------- |
| *Id     |追蹤單號，唯一值     |
| Summary     | 主旨，必填欄位     |
| Description    | 描述，必填欄位     |
| Reslove     |解決狀態(預設為false)     |
| CreateTime     | 建立時間     |
| UpdateTime     | 更新時間     |


* Phase II
- Adding new field Severity and Priority to a ticket.
- Adding new type of user “PM” that can create new ticket type “Feature Request”. And only RD can mark it as resolved.
- Adding new ticket type “Test Case” that only QA can create and resolve. It’s read-only for other type of users.
- Adding new type of user “Administrator” user that can manage all the stuffs including adding new QA, RD and PM user.

| Role | 功能 |新增| 修改 | 刪除 | 更新解決狀態 |
| -------- | -------- | -------- | -------- |-------- |-------- |
| QA     |  Ticket_BUG   | V     | V     |V     |     |
| RD     |  Ticket_BUG    |      |      |     |  V   |
| PM     |  Ticket_Feature Request    |   V   |      |     |     |
| RD     |  Ticket_Feature Request    |      |      |     |  V   |
| QA     |  Ticket_Test Case     |   V   |      |     |  V   |
| Administrator | Manage    |   V   |   V   | V    |     |

Ticket 項目資訊
| 名稱 | 描述 |
| -------- |  -------- |
| *Id     |追蹤單號，唯一值     |
| Type     |  單號類型0:Bug, 1:Feature Request,2:Test Case    |
| Summary     | 主旨，必填欄位     |
| Description    | 描述，必填欄位     |
| Severity     | 嚴重等級 0:Heigh,1:Medium,2:Low   |
| Priority    | 優先事項(預設為false)     |
| Reslove     |解決狀態(預設為false)     |
| CreateTime     | 建立時間     |
| UpdateTime     | 更新時間     |


---

# Task2

---

review my pjoect,please.
asp.net core + vue.js


---

# Task 3

---

## data model
**Bug Data Model**

| 名稱 | 型別 | 描述 |
| -------- | -------- | -------- |
| *id     | IDENTITY(1,1)     | 追蹤單號     |
| Summary     | varchar(64)     | 主旨     |
| Description    | varchar(512)     | 描述     |
| Reslove     | bit     | 解決狀態(預設為false)     |
| CreateTime     | DateTime     | 建立時間     |
| UpdateTime     | DateTime     | 更新時間     |

**Role Data Model**
| 名稱 | 型別 | 描述 |
| -------- | -------- | -------- |
| *id     | IDENTITY(1,1)     | 角色id     |
| Role     | varchar(64)     | 角色     |
| Create     | bit     | 新增     |
| Edit     | bit     | 修改     |
| Delete     | bit     | 刪除     |
| Reslove     | bit     | 更新解決狀態     |


## class diagram
![](https://i.imgur.com/IOGJssx.png)



## UI

<b>登入畫面，選擇權限</b>
![](https://i.imgur.com/CaxANfq.png)

<b>列表(QA)，QA可在此查詢新增編輯刪除</b>
1. 建立Bug按鈕
2. 顯示列表，右至左欄位顯示序號、主旨、描述、是否解決、功能清單
3. 是否解決：紅色為未解決、綠色為解決
4. 編輯按鈕、刪除按鈕放置在此區

![](https://i.imgur.com/tIukCCR.png)

<b>列表(RD)，RD可更新解決狀態</b>
1. 點選特定狀態，即可更新問題單的狀態，有底色代表目前選取狀態

![](https://i.imgur.com/AT6mxH3.png)

<b>新增，編輯畫面:由建立及編輯按鈕代入，按下Save即可儲存</b>
1. 按下儲存需驗證是否有輸入主旨及描述
2. 編輯打開的話，需代入原舊有內容
![](https://i.imgur.com/FXooWBO.png)



---

# Task 4

---

* 取得並驗證授權
```
POST https://tricksystem.com/api/v1/token
```

| Parameter | Type  | Required | Description |
| -------- | -------- | -------- | -------- |
| refresh_token     | string     | required    | A valid refresh token. |
| client_id     | string     | required    | Your integration’s clientId |
| client_secret     | string     | required    | Your integration’s clientSecret |
| grant_type     | string     | required    | The literal string "refresh_token" |

Response -ok
```
{"token":"181d415f34379af07b2c11d144dfbe35d"}
```
Response -error
```
{"token":""}
```


* 取得問題清單
```
POST https://tricksystem.com/api/v1/list
```

| Parameter | Type  | Required | Description |
| -------- | -------- | -------- | -------- |
| token     | string     | required    | A valid token. |
| resolve     | string     | no required    | true or false |
| datetime     | string     | no required     | bug create time |


Response-ok
```
{
  "data": [
    {
        "id": "1",
        "summary":"bug1",
        "Description": "bug1",
        "Reslove": true,
        "CreateTime": "2021/12/01 17:00:00"
    }

  ]
}
```