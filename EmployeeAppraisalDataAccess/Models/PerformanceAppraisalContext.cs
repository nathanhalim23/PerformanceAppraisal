using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAppraisalDataAccess.Models;

public partial class PerformanceAppraisalContext : DbContext
{
    public PerformanceAppraisalContext()
    {
    }

    public PerformanceAppraisalContext(DbContextOptions<PerformanceAppraisalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppraisalForm> AppraisalForms { get; set; }

    public virtual DbSet<AreaResponsibilityIndicator> AreaResponsibilityIndicators { get; set; }

    public virtual DbSet<BasicCompetency> BasicCompetencies { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<ImprovementArea> ImprovementAreas { get; set; }

    public virtual DbSet<KpiMaster> KpiMasters { get; set; }

    public virtual DbSet<PerformanceIndicator> PerformanceIndicators { get; set; }

    public virtual DbSet<PolarizationMaster> PolarizationMasters { get; set; }

    public virtual DbSet<ScoreAdjustment> ScoreAdjustments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Performance Appraisal;Username=postgres;Password=indocyber");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppraisalForm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("appraisal_form_pkey");

            entity.ToTable("appraisal_form");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nik)
                .HasColumnType("character varying")
                .HasColumnName("nik");
            entity.Property(e => e.Periode).HasColumnName("periode");

            entity.HasOne(d => d.NikNavigation).WithMany(p => p.AppraisalForms)
                .HasForeignKey(d => d.Nik)
                .HasConstraintName("appraisal_form_nik_fkey");
        });

        modelBuilder.Entity<AreaResponsibilityIndicator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("area_responsibility_indicator_pkey");

            entity.ToTable("area_responsibility_indicator");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Absent).HasColumnName("absent");
            entity.Property(e => e.AuditScore).HasColumnName("audit_score");
            entity.Property(e => e.Cpg).HasColumnName("cpg");
            entity.Property(e => e.ExternalAudit).HasColumnName("external_audit");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.InternalAudit).HasColumnName("internal_audit");
            entity.Property(e => e.IsoSmk3Application)
                .HasColumnType("character varying")
                .HasColumnName("iso_smk3_application");
            entity.Property(e => e.LessThanFifteenMinLate).HasColumnName("less_than_fifteen_min_late");
            entity.Property(e => e.MoreThan4HoursTraining).HasColumnName("more_than_4_hours_training");
            entity.Property(e => e.MoreThanFifteenMinLate).HasColumnName("more_than_fifteen_min_late");
            entity.Property(e => e.Nik)
                .HasColumnType("character varying")
                .HasColumnName("nik");
            entity.Property(e => e.OneAbsence).HasColumnName("one_absence");
            entity.Property(e => e.SickLeave).HasColumnName("sick_leave");
            entity.Property(e => e.TwoHoursLeave).HasColumnName("two_hours_leave");

            entity.HasOne(d => d.Form).WithMany(p => p.AreaResponsibilityIndicators)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("fk_appraisal_form");

            entity.HasOne(d => d.NikNavigation).WithMany(p => p.AreaResponsibilityIndicators)
                .HasForeignKey(d => d.Nik)
                .HasConstraintName("area_responsibility_indicator_nik_fkey");
        });

        modelBuilder.Entity<BasicCompetency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("basic_competency_pkey");

            entity.ToTable("basic_competency");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContinuousImprovement).HasColumnName("continuous_improvement");
            entity.Property(e => e.CustomerFocus).HasColumnName("customer_focus");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.Integrity).HasColumnName("integrity");
            entity.Property(e => e.Nik)
                .HasColumnType("character varying")
                .HasColumnName("nik");
            entity.Property(e => e.Teamwork).HasColumnName("teamwork");
            entity.Property(e => e.WorkExcellence).HasColumnName("work_excellence");

            entity.HasOne(d => d.Form).WithMany(p => p.BasicCompetencies)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("fk_appraisal_form");

            entity.HasOne(d => d.NikNavigation).WithMany(p => p.BasicCompetencies)
                .HasForeignKey(d => d.Nik)
                .HasConstraintName("basic_competency_nik_fkey");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comments_pkey");

            entity.ToTable("comments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppraiserComment)
                .HasColumnType("character varying")
                .HasColumnName("appraiser_comment");
            entity.Property(e => e.EmployeeComment)
                .HasColumnType("character varying")
                .HasColumnName("employee_comment");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.Nik)
                .HasColumnType("character varying")
                .HasColumnName("nik");

            entity.HasOne(d => d.Form).WithMany(p => p.Comments)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("fk_appraisal_form");

            entity.HasOne(d => d.NikNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.Nik)
                .HasConstraintName("comments_nik_fkey");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("division_pkey");

            entity.ToTable("division");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Nik).HasName("employee_pkey");

            entity.ToTable("employee");

            entity.Property(e => e.Nik)
                .HasColumnType("character varying")
                .HasColumnName("nik");
            entity.Property(e => e.DivisionId).HasColumnName("division_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Position)
                .HasColumnType("character varying")
                .HasColumnName("position");
            entity.Property(e => e.SuperiorId)
                .HasColumnType("character varying")
                .HasColumnName("superior_id");

            entity.HasOne(d => d.Division).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DivisionId)
                .HasConstraintName("employee_division_id_fkey");

            entity.HasOne(d => d.Superior).WithMany(p => p.InverseSuperior)
                .HasForeignKey(d => d.SuperiorId)
                .HasConstraintName("employee_superior_id_fkey");
        });

        modelBuilder.Entity<ImprovementArea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("improvement_area_pkey");

            entity.ToTable("improvement_area");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.ImorovementMethod)
                .HasColumnType("character varying")
                .HasColumnName("imorovement_method");
            entity.Property(e => e.ImprovementAreaNeeded)
                .HasColumnType("character varying")
                .HasColumnName("improvement_area_needed");
            entity.Property(e => e.Nik)
                .HasColumnType("character varying")
                .HasColumnName("nik");

            entity.HasOne(d => d.Form).WithMany(p => p.ImprovementAreas)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("fk_appraisal_form");

            entity.HasOne(d => d.NikNavigation).WithMany(p => p.ImprovementAreas)
                .HasForeignKey(d => d.Nik)
                .HasConstraintName("improvement_area_nik_fkey");
        });

        modelBuilder.Entity<KpiMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("kpi_master_pkey");

            entity.ToTable("kpi_master");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<PerformanceIndicator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("performance_indicator_pkey");

            entity.ToTable("performance_indicator");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Actual).HasColumnName("actual");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.KpiId).HasColumnName("kpi_id");
            entity.Property(e => e.Nik)
                .HasColumnType("character varying")
                .HasColumnName("nik");
            entity.Property(e => e.PolarizationId).HasColumnName("polarization_id");
            entity.Property(e => e.StrategicObjective)
                .HasColumnType("character varying")
                .HasColumnName("strategic_objective");
            entity.Property(e => e.UnitOfMeasurement)
                .HasColumnType("character varying")
                .HasColumnName("unit_of_measurement");

            entity.HasOne(d => d.Form).WithMany(p => p.PerformanceIndicators)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("fk_appraisal_form");

            entity.HasOne(d => d.Kpi).WithMany(p => p.PerformanceIndicators)
                .HasForeignKey(d => d.KpiId)
                .HasConstraintName("performance_indicator_kpi_id_fkey");

            entity.HasOne(d => d.NikNavigation).WithMany(p => p.PerformanceIndicators)
                .HasForeignKey(d => d.Nik)
                .HasConstraintName("performance_indicator_nik_fkey");

            entity.HasOne(d => d.Polarization).WithMany(p => p.PerformanceIndicators)
                .HasForeignKey(d => d.PolarizationId)
                .HasConstraintName("performance_indicator_polarization_id_fkey");
        });

        modelBuilder.Entity<PolarizationMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("polarization_master_pkey");

            entity.ToTable("polarization_master");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<ScoreAdjustment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("score_adjustment_pkey");

            entity.ToTable("score_adjustment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FormId).HasColumnName("form_id");
            entity.Property(e => e.IsAuditorOrTrainer).HasColumnName("is_auditor_or_trainer");
            entity.Property(e => e.IsFireIncident).HasColumnName("is_fire_incident");
            entity.Property(e => e.IsLostTimeInjury).HasColumnName("is_lost_time_injury");
            entity.Property(e => e.IsProject).HasColumnName("is_project");
            entity.Property(e => e.IsSga).HasColumnName("is_sga");
            entity.Property(e => e.IsWarningLetter).HasColumnName("is_warning_letter");
            entity.Property(e => e.Nik)
                .HasColumnType("character varying")
                .HasColumnName("nik");

            entity.HasOne(d => d.Form).WithMany(p => p.ScoreAdjustments)
                .HasForeignKey(d => d.FormId)
                .HasConstraintName("fk_appraisal_form");

            entity.HasOne(d => d.NikNavigation).WithMany(p => p.ScoreAdjustments)
                .HasForeignKey(d => d.Nik)
                .HasConstraintName("score_adjustment_nik_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Username)
                .HasColumnType("character varying")
                .HasColumnName("username");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasColumnType("character varying")
                .HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
