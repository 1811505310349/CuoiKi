namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAccount")]
    public partial class UserAccount
    {
        public long ID { get; set; }

        [Display(Name ="Tài khoản")]
        [StringLength(50)]
        public string Username { get; set; }
        [Display(Name = "Mật khẩu")]
        [StringLength(50)]
        public string Password { get; set; }
        [Display(Name = "Trạng thái")]
        [StringLength(40)]
        public string Status { get; set; }
    }
}
