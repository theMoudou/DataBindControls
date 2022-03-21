<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryBootStrap2.aspx.cs" Inherits="WebAPISample.TryBootStrap2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>試用 BootStrap</title>

    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-4 col-sm-6">
                    Left Column
                </div>
                <div class="col-md-4 col-sm-6">
                    <div id="FakeDataList">
                    
                    </div>


                    <div class="modal" id="exampleModal" tabindex="-1">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title">
                                        <asp:Literal runat="server" ID="ltlModalTitle">警示文字</asp:Literal>
                                    </h5>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">
                                    <p>
                                        <asp:Literal runat="server" ID="ltlModalContent">請注意，存檔後將會覆蓋現有資料。</asp:Literal>
                                    </p>

                                    <div class="mb-3">
                                        <input type="hidden" name="FakeDataID" />

                                        <label for="exampleFormControlInput1" class="form-label">標題</label>
                                        <input type="text" class="form-control" name="txtName" />
                                    </div>
                                    <div class="mb-3">
                                        <label for="exampleFormControlTextarea1" class="form-label">內文</label>
                                        <textarea class="form-control" rows="3" name="txtContent"></textarea>
                                    </div>

                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">關閉</button>
                                    <button type="button" id="btnSaveFakeData" class="btn btn-primary">儲存</button>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

                <div class="col-md-4 col-sm-6">
                    Right Column 
                </div>
            </div>
        </div>
    </form>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/jquery.min.js"></script>
    <script>
    $(document).ready(function () {
        // 建立表格
        function BuildTable() {
            $.ajax({
                url: "/API/FakeDataHandler.ashx",
                method: "GET",
                dataType: "JSON",
                success: function (objDataList) {
                    console.log(objDataList);

                    var rowsText = "";
                    for (var item of objDataList) {
                        rowsText +=
                            `
                            <tr>
                                <td> ${item.ID} </td>
                                <td> ${item.Name} </td>
                                <td>
                                    <div>
                                        <input type="hidden" class="hfID" value="${item.ID}">
                                        <button type="button" class="btn btn-primary btnEdit" data-bs-toggle="modal" data-bs-target="#exampleModal">
                                            編輯
                                        </button>
                                        <button type="button" class="btn btn-primary btnDelete">
                                            刪除
                                        </button>
                                    </div>
                                </td>
                            </tr>
                        `;
                    }
                    $("#FakeDataList").empty();
                    $("#FakeDataList").append("<table>" + rowsText + "</table>");
                },
                error: function (msg) {
                    console.log(msg);
                    alert("通訊失敗，請聯絡管理員。");
                }
            });
        }
        BuildTable();

        // 點擊存檔
        $("#btnSaveFakeData").click(function () {
            var container = $("#exampleModal");
            var postData = {
                "ID": $("input[name=FakeDataID]", container).val(),
                "Name": $("input[name=txtName]", container).val(),
                "Content": $("textarea[name=txtContent]", container).val()
            };

            $.ajax({
                url: "/API/FakeDataHandler.ashx?Action=Update",
                method: "POST",
                data: postData,
                //dataType: "JSON",
                success: function (txtMsg) {
                    console.log(txtMsg);
                    if (txtMsg == "OK") {
                        BuildTable();
                        alert("更新成功");
                    } else {
                        alert("更新失敗，請聯絡管理員。");
                    }
                },
                error: function (msg) {
                    console.log(msg);
                    alert("通訊失敗，請聯絡管理員。");
                }
            });
        });

        // 點擊編輯
        $("#FakeDataList").on("click", ".btnEdit", function () {
            var parentDiv = $(this).closest("div");
            var hf = parentDiv.find("input.hfID");

            $.ajax({
                url: "/API/FakeDataHandler.ashx",
                method: "GET",
                data: { "ID": hf.val() },
                dataType: "JSON",
                success: function (objData2) {
                    console.log(objData2);
                    //alert(objData);

                    $("#exampleModal input[name=FakeDataID]").val(objData2.ID);
                    $("#exampleModal input[name=txtName]").val(objData2.Name);
                    $("#exampleModal textarea[name=txtContent]").text(objData2.Content);
                },
                error: function (msg2) {
                    console.log(msg2);
                    alert("通訊失敗，請聯絡管理員。");
                }
            });
        });

        // 點擊刪除
        $("#FakeDataList").on("click", ".btnDelete", function () {
            var parentDiv = $(this).closest("div");
            var hf = parentDiv.find("input.hfID");
            if (!confirm("確定要刪除嗎?"))
                return false;

            $.ajax({
                url: "/API/FakeDataHandler.ashx?Action=Delete",
                method: "POST",
                data: { "ID": hf.val() },
                success: function (txtMsg) {
                    console.log(txtMsg);
                    if (txtMsg == "OK") {
                        BuildTable();
                        alert("刪除成功");
                    } else {
                        alert("刪除失敗，請聯絡管理員。");
                    }
                },
                error: function (msg) {
                    console.log(msg);
                    alert("通訊失敗，請聯絡管理員。");
                }
            });
        });
    })
    </script>
</body>
</html>
