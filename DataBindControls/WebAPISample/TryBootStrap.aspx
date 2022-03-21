<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryBootStrap.aspx.cs" Inherits="WebAPISample.TryBootStrap" %>


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
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="下一步" CssClass="btn btn-primary btn-sm" OnClick="Button1_Click" /><br />
                    <asp:Button ID="Button2" runat="server" Text="完成" CssClass="btn btn-success btn-lg" OnClick="Button2_Click" /><br />
                    <asp:Button ID="Button3" runat="server" Text="取消" CssClass="btn btn-danger btn-sm"
                        OnClientClick="return btn3_Click()" />
                    <button type="button" class="btn btn-info btn-sm" id="btn1">上一步</button>
                </div>
                <div class="col-md-4 col-sm-6">


                    <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
                        存檔
                    </button>

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
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">關閉</button>
                                    <%--<button type="button" class="btn btn-primary">確定</button>--%>
                                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="儲存" OnClick="btnSave_Click" />
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

                <div class="col-md-4 col-sm-6">
                    Right Column 
                    
                    <div class="mb-3">
                        <label for="exampleFormControlInput1" class="form-label">Email address</label>
                        <input type="email" class="form-control" id="exampleFormControlInput1" placeholder="name@example.com" name="testTextBox" />
                    </div>
                    <div class="mb-3">
                        <label for="exampleFormControlTextarea1" class="form-label">Example textarea</label>
                        <textarea class="form-control" id="exampleFormControlTextarea1" rows="3" name="testTextArea"></textarea>
                    </div>

                    <input type="submit" />
                </div>
            </div>
        </div>
    </form>
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/jquery.min.js"></script>
    <script>


        $(document).ready(function () {

        })
    </script>
</body>
</html>
