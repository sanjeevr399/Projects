<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestForm.aspx.cs" Inherits="Validationprj.TestForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            function validateForm() {
                var name = document.getElementById("naam").value.trim();
                var familyName = document.getElementById("familynaam").value.trim();
                var address = document.getElementById("address").value.trim();
                var city = document.getElementById("city").value.trim();
                var zipCode = document.getElementById("pincode").value.trim();
                var phone = document.getElementById("number").value.trim();
                var email = document.getElementById("gmail").value.trim();

                var errors = [];

                if (name === '') {
                    errors.push("Name is required.");
                    document.getElementById("RequiredFieldValidator1").style.display = "inline";
                } else {
                    document.getElementById("RequiredFieldValidator1").style.display = "none";
                }

                if (familyName === '') {
                    errors.push("Family name is required.");
                    document.getElementById("RequiredFieldValidator7").style.display = "inline";
                } else {
                    document.getElementById("RequiredFieldValidator7").style.display = "none";
                }

                if (familyName === name) {
                    errors.push("Family name should differ from Name.");
                    document.getElementById("CompareValidator1").style.display = "inline";
                } else {
                    document.getElementById("CompareValidator1").style.display = "none";
                }

                if (address.length < 2) {
                    errors.push("Address should be at least 2 characters.");
                    document.getElementById("RequiredFieldValidator2").style.display = "inline";
                } else {
                    document.getElementById("RequiredFieldValidator2").style.display = "none";
                }

                if (city.length < 2) {
                    errors.push("City should be at least 2 characters.");
                    document.getElementById("RequiredFieldValidator3").style.display = "inline";
                } else {
                    document.getElementById("RequiredFieldValidator3").style.display = "none";
                }

                if (!/^\d{5}$/.test(zipCode)) {
                    errors.push("Zip code should be 5 digits.");
                    document.getElementById("RegularExpressionValidator3").style.display = "inline";
                } else {
                    document.getElementById("RegularExpressionValidator3").style.display = "none";
                }

                if (!/^\d{2}-\d{7}$/.test(phone) && !/^\d{3}-\d{7}$/.test(phone)) {
                    errors.push("Phone number should be in the format XX-XXXXXXX or XXX-XXXXXXX.");
                    document.getElementById("RegularExpressionValidator1").style.display = "inline";
                } else {
                    document.getElementById("RegularExpressionValidator1").style.display = "none";
                }

                if (!/\S+@\S+\.\S+/.test(email)) {
                    errors.push("Email is invalid.");
                    document.getElementById("RegularExpressionValidator2").style.display = "inline";
                } else {
                    document.getElementById("RegularExpressionValidator2").style.display = "none";
                }

                if (errors.length > 0) {
                    var errorList = document.getElementById("errorList");
                    errorList.innerHTML = "";
                    errors.forEach(function (error) {
                        var li = document.createElement("li");
                        li.textContent = error;
                        errorList.appendChild(li);
                    });
                    alert("Validation Errors:\n" + errors.join("\n"));
                    return false;
                }

                return true;
            }

            document.getElementById("form1").onsubmit = function () {
                return validateForm();
            };
        });
    </script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return validateForm();">
        <div style="margin-left: 2px">
            Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="naam" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="naam" ErrorMessage="Name cannot be blank" ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <br />
            Family Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="familynaam" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="familynaam" Display="Dynamic" ErrorMessage="Family Name cannot be blank" ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="naam" ControlToValidate="familynaam" ErrorMessage="Differs from name" ForeColor="Red" Operator="NotEqual"></asp:CompareValidator>
            <br />
            <br />
            Address:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            <asp:TextBox ID="address" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="address" Display="Dynamic" ErrorMessage="Address cannot be blank" ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="address" Display="Dynamic" ErrorMessage="Address must be at least two characters long" ForeColor="Red" ValidationExpression=".{2,}"></asp:RegularExpressionValidator>
            <br />
            <br />
            City:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="city" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="city" ErrorMessage="City cannot be blank" ForeColor="Red" Display="Dynamic">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="city" Display="Dynamic" ErrorMessage="City must be at least two characters long" ForeColor="Red" ValidationExpression=".{2,}"></asp:RegularExpressionValidator>
            <br />
            <br />
            Zip Code:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            <asp:TextBox ID="pincode" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="pincode" ErrorMessage="Zip code cannot be blank" ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="pincode" ErrorMessage="Zip Code must be in 5 digits" ForeColor="Red" ValidationExpression="\d{5}"></asp:RegularExpressionValidator>
            <br />
            <br />
            Phone:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            <asp:TextBox ID="number" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="number" ErrorMessage="Phone Number cannot be blank" ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="number" ErrorMessage="(XX-XXXXXXXX / XXX-XXXXXXX)" ForeColor="Red" ValidationExpression="^\d{2,3}-\d{7,8}$"></asp:RegularExpressionValidator>
            <br />
            <br />
            E-mail:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="gmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="gmail" ErrorMessage="Email cannot be blank" ForeColor="Red">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="gmail" ErrorMessage="example@gmail.com" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Button ID="btn" runat="server" Text="Check" Style="float: right; margin-left: 57px;" OnClick="btn_Click" Width="99px" />
            <br />
            <br />
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            <br />
            <br />
            <ul id="errorList"></ul>
        </div>
    </form>
</body>
</html>
