using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ndc.Library.Constant
{
    public static class ResultConstant
    {
        //Common result
        public static KeyValuePair<long, string> Success = new KeyValuePair<long, string>(0, "Thành công");
        public static KeyValuePair<long, string> Fail = new KeyValuePair<long, string>(1, "Thất bại");

        //Account common error
        public static KeyValuePair<long, string> UserExisted = new KeyValuePair<long, string>(101, "Người dùng đã tồn tại");
        public static KeyValuePair<long, string> UserNotExisted = new KeyValuePair<long, string>(102, "Người dùng không tồn tại");
        public static KeyValuePair<long, string> PasswordWrong = new KeyValuePair<long, string>(103, "Sai mật khẩu");
        public static KeyValuePair<long, string> UserInactivated = new KeyValuePair<long, string>(104, "Người dùng chưa kích hoạt");
        

        //System error
        public static KeyValuePair<long, string> ConnectionError = new KeyValuePair<long, string>(400, "Lỗi kết nối");
        public static KeyValuePair<long, string> NotFound = new KeyValuePair<long, string>(404, "Không tìm thấy");
        public static KeyValuePair<long, string> NotHandleException = new KeyValuePair<long, string>(500, "Lỗi không xác định");
    }
}
