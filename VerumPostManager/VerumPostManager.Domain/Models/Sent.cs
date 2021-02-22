using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerumPostManager.Domain.Models
{
    public class Sent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        [MaxLength(200)]
        public string Comment { get; set; }

        [MaxLength(200)]
        public string Attachment { get; set; }

        [Required]
        public bool ConfirmationOfSending { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Customer Sender { get; set; }

        [Required]
        public Customer Recipient { get; set; }

        [Required]
        public Employee Employee { get; set; }
    }
}
