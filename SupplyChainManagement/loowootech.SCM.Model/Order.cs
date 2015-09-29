﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LoowooTech.SCM.Model
{
    /// <summary>
    /// 部件进货订单
    /// </summary>
    [Table("orders")]
    public class Order
    {
        public Order()
        {
            this.CreateTime = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 快递单
        /// </summary>
        public string Express { get; set; }
        /// <summary>
        /// 合同
        /// </summary>
        public string Indenture { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public int EnterpriseId { get; set; }

        [Column(TypeName="int")]
        public OrderType Type { get; set; }

        [Column(TypeName="int")]
        public State State { get; set; }

        [NotMapped]
        public Enterprise Enterprise { get; set; }

        [NotMapped]
        public Remittance Remittance { get; set; }
        
    }


    public enum State
    {
        [Description("订单生成")]
        Place,
        [Description("发货")]
        Shipping,
        [Description("完成")]
        Done,
        [Description("退货")]
        Turn,
        [Description("已汇款")]
        Payment
    }

    public enum OrderType
    {
        [Description("进货")]
        Bought,
        [Description("出货")]
        Shipment
    }
}
