<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QLSinhVien.aspx.cs" Inherits="WebQLDaoTao.QLSinhVien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <h2>QUẢN LÝ SINH VIÊN</h2>
    <!-- Trigger the modal with a button -->
<button type="button" class="btn btn-info" data-toggle="modal" data-target="#myModal">Thêm sinh viên</button>

<!-- Modal -->
<div id="myModal" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Thêm sinh viên</h4>
            </div>
            <div class="modal-body">
                <div class="mb-3 row">
                    <label for="txtMaSV" class="col-sm-3 col-form-label">Mã sinh viên</label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtMaSV" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3 row">
                    <label for="txtHoTen" class="col-sm-3 col-form-label">Họ và tên</label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtHoTen" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3 row">
                    <label for="txtNgaySinh" class="col-sm-3 col-form-label">Ngày sinh</label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtNgaySinh" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3 row">
                    <label for="txtDiaChi" class="col-sm-3 col-form-label">Địa chỉ</label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtDiaChi" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3 row">
                    <label for="txtDiaChi" class="col-sm-3 col-form-label">Mã khoa</label>
                    <div class="col-sm-6">
                        <asp:DropDownList ID="ddlMaKh" DataSourceID="odsKhoa" DataTextField="tenkh" DataValueField="makh" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
           <%-- <div class="modal-footer">
                <asp:Button ID="btnLuuSinhVien" OnClick="btnLuuSinhVien_Click" runat="server" Text="Lưu" CssClass="btn btn-primary" />
                <button type="button" class="btn btn-default" data-dismiss="modal">Đóng</button>
            </div>--%>
        </div>
    </div>
</div>

    <hr />
    <div class="table-responsive">
        <asp:GridView ID="gvSinhVien" runat="server" CssClass="table table-bordered table-hover" 
            AutoGenerateColumns="False" DataSourceID="odsSinhVien" AllowPaging="True" PageSize="5">
            <Columns>
                <asp:BoundField DataField="MaSV" HeaderText="Mã SV" ReadOnly="true" />
                <asp:BoundField DataField="HoSV" HeaderText="Họ SV" />
                <asp:BoundField DataField="TenSV" HeaderText="Tên SV" />
                <asp:CheckBoxField DataField="GioiTinh" HeaderText="Giới tính" />
                <asp:BoundField DataField="NgaySinh" HeaderText="Ngày sinh" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="NoiSinh" HeaderText="Nơi sinh" />
                <asp:BoundField DataField="DiaChi" HeaderText="Địa chỉ" SortExpression="DiaChi" />
                <asp:BoundField DataField="MaKH" HeaderText="Khoa" SortExpression="MaKH" />
                <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" ButtonType="Button"
                    EditText="Sửa" DeleteText="Xoá" UpdateText="Ghi" CancelText="Không" ItemStyle-Wrap="false" />
                
            </Columns>
            <PagerStyle CssClass="pagination-xs" HorizontalAlign="Center" />
        </asp:GridView>
        </div>
        <asp:ObjectDataSource ID="odsSinhVien" runat="server" DataObjectTypeName="WebQLDaoTao.Models.SinhVien" SelectMethod="getAll" TypeName="WebQLDaoTao.Models.SinhVienDAO" UpdateMethod="Update" />
        <asp:ObjectDataSource ID="odsKhoa" runat="server" SelectMethod="getAll" TypeName="WebQLDaoTao.Models.KhoaDAO"></asp:ObjectDataSource>
</asp:Content>
