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
    
    public partial class cart
    {
        public int transaction_id { get; set; }
        public int skin_id { get; set; }
        public int user_id { get; set; }
    
        public virtual skins skins { get; set; }
        public virtual users users { get; set; }
    }
}
