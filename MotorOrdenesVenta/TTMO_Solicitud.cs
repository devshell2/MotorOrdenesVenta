//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MotorOrdenesVenta
{
    using System;
    using System.Collections.Generic;
    
    public partial class TTMO_Solicitud
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TTMO_Solicitud()
        {
            this.TTMO_ResultadoEnvio = new HashSet<TTMO_ResultadoEnvio>();
        }
    
        public int CD_Solicitud { get; set; }
        public int TCMO_EstatusSolicitud_CD_EstatusSolicitud { get; set; }
        public Nullable<int> NU_job { get; set; }
        public Nullable<int> NU_Serie { get; set; }
        public Nullable<int> NU_customer { get; set; }
        public Nullable<int> NU_deliveryAddress { get; set; }
        public string TX_TermDelivery { get; set; }
        public Nullable<int> NU_TermPayment { get; set; }
        public string TX_ForwardAgent { get; set; }
        public string TX_Country { get; set; }
        public string TX_Refb { get; set; }
        public Nullable<int> NU_Position { get; set; }
        public string TX_Item { get; set; }
        public Nullable<int> NU_Quantity { get; set; }
        public Nullable<decimal> IM_Price { get; set; }
        public string NU_Currency { get; set; }
        public Nullable<decimal> IM_Amount { get; set; }
        public int TCMO_TipoSolicitud_IdTipoSolicitud { get; set; }
    
        public virtual TCMO_EstatusSolicitud TCMO_EstatusSolicitud { get; set; }
        public virtual TCMO_TipoSolicitud TCMO_TipoSolicitud { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TTMO_ResultadoEnvio> TTMO_ResultadoEnvio { get; set; }
    }
}
