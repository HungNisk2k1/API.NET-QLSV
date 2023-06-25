using System;
using System.Collections.Generic;
using System.Text;

namespace NHCH.ULT
{
    public class Constant
    {
        public static readonly DateTime DEFAULT_DATE = DateTime.ParseExact("01/01/1753 12:00:00 AM", "dd/MM/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);

        public static readonly String CAPNHAT = "Cập nhật thông tin ";
        public static readonly String THEMMOI = "Thêm mới thông tin ";
        public static readonly String XOA = "Xóa thông tin ";

        public static readonly string API_Error_System = "Lỗi hệ thống, vui lòng liên hệ admin để được hỗ trợ!";
        public static readonly String MSG_SUCCESS = "Cập nhật dữ liệu thành công.";
        public static readonly String NO_FILE = "Không tìm thấy file cần download.";
        public static readonly String NO_DATA = "Không có dữ liệu.";
        public static readonly String ERR_INSERT = "Xảy ra lỗi trong quá trình thêm mới dữ liệu. Vui lòng liên hệ quản trị để biết thêm thông tin!";
        public static readonly String ERR_UPDATE = "Xảy ra lỗi trong quá trình cập nhật dữ liêụ. Vui lòng liên hệ quản trị để biết thêm thông tin!";
        public static readonly String ERR_DELETE = "Xảy ra lỗi trong quá trình xóa dữ liệu. Vui lòng liên hệ quản trị để biết thêm thông tin!";
        public static readonly String ERR_UPLOAD = "Xảy ra lỗi trong quá trình upload file.";
        public static readonly String ERR_FILENOTFOUND = "Không tìm thấy file bạn cần download.";
        public static readonly String ERR_EXP_TOKEN = "Phiên làm việc đã hết hạn! Xin vui lòng đăng nhập lại.";
        public static readonly String NOT_ACCESS = "Người dùng không có quyền sử dụng chức năng này.";

        public static readonly String NOT_ACCOUNT = "Tài khoản hoặc mật khẩu không đúng.";
        public static readonly String NOT_ACCOUNT_CAS = "Email chưa được đăng ký trên hệ thống. Vui lòng kiểm tra lại";
        public static readonly String NOT_USERTrangThai = "Tài khoản của bị đang bị khóa, vui lòng liên hệ quản trị viên để được hỗ trợ.";
        public static readonly String NOT_USERACTIVE = "Tài khoản của bạn chưa được kích hoạt, vui lòng kiểm tra Email để kích hoạt.";
        public static readonly string NOT_ACTIVE = "Tài khoản hiện tại đã ngưng hoạt động. Vui lòng liên hệ quản trị để biết thêm thông tin chi tiết. Xin cảm ơn.";
        public static readonly String NOT_USER_ACTIVE = "Tài khoản hiện chưa được kích hoạt. Vui lòng liên hệ quản trị để biết thêm thông tin chi tiết. Xin cảm ơn.";
        public static readonly string NOT_EXPIRED = "Tài khoản hiện tại đã hết hạn sử dụng gói dịch vụ. Vui lòng liên hệ quản trị để biết thêm thông tin chi tiết. Xin cảm ơn.";
        public static String GetUserMessage(int status)
        {
            switch (status)
            {
                default: return String.Empty;
                case 0: return NO_DATA;
                case -99: return ERR_EXP_TOKEN;
                case -98: return NOT_ACCESS;
            }
        }

        public static String GetSysMessage(int status)
        {
            switch (status)
            {
                default: return String.Empty;
                case 0: return NO_DATA;
                case -99: return ERR_EXP_TOKEN;
            }
        }
    }
}
