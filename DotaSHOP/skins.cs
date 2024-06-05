//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DotaSHOP
{
    using System;
    using System.Collections.Generic;
    
    public partial class skins
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public skins()
        {
            this.cart = new HashSet<cart>();
            this.favorites = new HashSet<favorites>();
        }
    
        public int skin_id { get; set; }
        public string skinname { get; set; }
        public string hero { get; set; }
        public int slotID { get; set; }
        public Nullable<decimal> price { get; set; }
        public string image_url { get; set; }
        public string Image { get; set; }
        public string CurrentPhoto
        {
            get
            {
                if (String.IsNullOrEmpty(image_url) || String.IsNullOrWhiteSpace(image_url))
                {
                    return "img/skins/picture.jpg";
                }
                else
                {
                    return "img/skins/" + image_url;
                }
            }
        }
        public string description { get; set; }
        public int rarityID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cart> cart { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<favorites> favorites { get; set; }
        public virtual rarcategory rarcategory { get; set; }
        public virtual slotcategory slotcategory { get; set; }
    }
}
