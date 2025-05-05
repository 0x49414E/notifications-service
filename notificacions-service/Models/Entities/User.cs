using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace notificacions_service.Models.Entities
{
    [Table("users")]
    public class User
    {
        [Column("user_id")]
        public int? id { get; set; }
        [Column("email")]
        public string? email { get; set; }
        [Column("password_hash")]
        public string? passwordHash { get; set; }
        [Column("first_name")]
        public string? firstName { get; set; }
        [Column("last_name")]
        public string? lastName { get; set; }
        [Column("updated_at")]
        public DateTime updateAt { get; set; }
        [Column("active")]
        public byte active { get; set; }
        [Column("email_confirmed")]
        public byte emailConfirmed { get; set; }
        [Column("email_confirmation_token")]
        public string? emailConfirmationToken { get; set; }
        [Column("refresh_token")]
        public string? refreshToken { get; set; }
        [Column("refresh_token_expiry")]
        public DateTime? refreshTokenExpiry { get; set; }
        [Column("password_reset_token")]
        public string? passwordResetToken { get; set; }
        [Column("password_reset_token_expiry")]
        public DateTime? passwordResetTokenExpiry { get; set; }
    }
}

