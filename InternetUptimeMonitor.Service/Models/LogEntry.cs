using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JDMallen.Toolbox.Extensions;
using JDMallen.Toolbox.Infrastructure.EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetUptimeMonitor.Service.Models
{
	[Table("LogEntry")]
	public class LogEntry : IComplexEntityModel<int>
	{
		[Key]
		[Column("Id", TypeName = "INTEGER")]
		public int Id { get; set; }
		
		[Column("EventId", TypeName = "INTEGER")]
		public int EventId { get; set; }
		
		[Column("DateCreated")]
		public long DateCreatedUnix { get; set; }
		
		[Column("DateModified")]
		public long DateModifiedUnix { get; set; }

		[Column("LogLevel", TypeName = "VARCHAR(50)")]
		public string LogLevel { get; set; }
		
		[Column("Message", TypeName = "TEXT")]
		public string Message { get; set; }

		[NotMapped]
		public DateTime DateCreated
		{
			get => DateCreatedUnix.FromUnixTimeMillis();
			set => DateCreatedUnix = value.ToUnixTimeMillis();
		}

		[NotMapped]
		public DateTime DateModified
		{
			get => DateModifiedUnix.FromUnixTimeMillis();
			set => DateModifiedUnix = value.ToUnixTimeMillis();
		}

		public void OnModelCreating(ModelBuilder modelBuilder)
		{
//			throw new NotImplementedException();
		}
	}
}
