namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public long ID { get; set; }
        [Display(Name = "Tên sản phẩm")]
        [StringLength(250)]
        public string Name { get; set; }
        [Display(Name = "Giá")]
        public decimal? UnitCost { get; set; }
        [Display(Name = "Số lượng")]
        public int? Quantity { get; set; }
        [Display(Name = "Ảnh")]
        [StringLength(250)]
        public string Image { get; set; }
        [Display(Name = "Mô tả")]
        [StringLength(255)]
        public string Description { get; set; }
        [Display(Name = "Trạng thái")]
        public int? Status { get; set; }
        [Display(Name = "Loại sản phẩm")]
        public long? ProductType { get; set; }

        public virtual Category Category { get; set; }
    }
}
