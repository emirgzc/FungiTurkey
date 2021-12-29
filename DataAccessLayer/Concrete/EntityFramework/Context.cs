using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
	public class Context:DbContext
	{
		public DbSet<About> Abouts { get; set; }
		public DbSet<Activity> Activities { get; set; }
		public DbSet<Admin> Admins { get; set; }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Galery> Galeries { get; set; }
		public DbSet<Member> Members { get; set; }
		public DbSet<Record> Records { get; set; }
		public DbSet<Services> Services { get; set; }
		public DbSet<Settings> Settings { get; set; }
		public DbSet<SettingsPage> SettingsPages { get; set; }
		public DbSet<Slider> Sliders { get; set; }
		public DbSet<Sponsor> Sponsors { get; set; }
		public DbSet<Statistic> Statistics { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<ActivityComment> ActivityComments { get; set; }
		public DbSet<BlogComment> BlogComments { get; set; }
		public DbSet<Message> Messages { get; set; }
	}
}
