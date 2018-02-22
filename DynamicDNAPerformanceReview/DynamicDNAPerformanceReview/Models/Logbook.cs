using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DynamicDNAPerformanceReview.Models
{
    public class Logbook
    {

        //The information


        [Required(ErrorMessage = "Please ignore unless incorrect")]

        [Display(Name = "Learner's Name:")]
        public string LearnerName { get; set; }

        [Display(Name = "Mentor's Name:")]
        [Required(ErrorMessage = "Please ignore unless incorrect")]
        public string MentorName { get; set; }

        [Display(Name = "Mentors's Tel:")]
        [Required(ErrorMessage = "Please ignore unless incorrect")]
        public string MentorTel { get; set; }

        [Required(ErrorMessage = "Select appropriate")]
        [Display(Name = "Learnership Intake:")]
        public string Learnership { get; set; }
        [Required(ErrorMessage = "Select appropriate")]
        [Display(Name = "Company Name:")]
        public string CompanyName { get; set; }


        //Day One--Monday


        [DataType(DataType.Date)]

        [Display(Name = "Monday's Date:")]
        [Required(ErrorMessage = "Please verify Monday's Date")]
        [DisplayFormat(DataFormatString = "{MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Day01 { get; set; }




        [Required]
        [Display(Name = "Task Completed:")]
        public string TaskDay01 { get; set; }


        [Required(ErrorMessage = "Please ignore unless incorrect")]
        [Display(Name = "Completed(Satisfactory)?:")]
        public string CompletedSatDay01 { get; set; }


        [Required(ErrorMessage = "Please ignore unless incorrect")]
        [Display(Name = "Time Taken(Hours):")]
        public string TimeTakenDay01 { get; set; }


        //[Required]
        [Display(Name = "Problems Experienced(If Any)")]
        public string ProblemsDay01 { get; set; }
        [Display(Name = "General Comments:")]

        //[Required]
        public string CommentsDay01 { get; set; }


        //Day 2 Tuesday

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please verify Tuesdays's Date")]
        [Display(Name = "Tuesday's Date:")]
        [DisplayFormat(DataFormatString = "{0:DD-MM-YYYY}", ApplyFormatInEditMode = true)]
        public DateTime? Day02 { get; set; }

        [Required]
        [Display(Name = "Task Completed:")]
        public string TaskDay02 { get; set; }


        [Required(ErrorMessage = "Please ignore unless incorrect")]
        [Display(Name = "Completed(Satisfaction)?:")]
        public string CompletedSatDay02 { get; set; }


        [Required(ErrorMessage = "Please ignore unless incorrect")]
        [Display(Name = "Time Taken(Hours):")]
        public string TimeTakenDay02 { get; set; }


        //[Required]
        [Display(Name = "Problems Experienced(If any)")]
        public string ProblemsDay02 { get; set; }
        [Display(Name = "General Comments:")]

        //[Required]
        public string CommentsDay02 { get; set; }

        //Day 03 Wednesday

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please verify Thursday's Date")]
        [Display(Name = "Wednesday's Date:")]
        [DisplayFormat(DataFormatString = "{0:DD-MM-YYYY}", ApplyFormatInEditMode = true)]
        public DateTime? Day03 { get; set; }

        [Required]
        [Display(Name = "Task Completed:")]
        public string TaskDay03 { get; set; }


        [Required(ErrorMessage = "Please ignore unless incorrect")]
        [Display(Name = "Completed(Satisfaction)?:")]
        public string CompletedSatDay03 { get; set; }


        [Required(ErrorMessage = "Please ignore unless incorrect")]
        [Display(Name = "Time Taken(Hours):")]
        public string TimeTakenDay03 { get; set; }


        //[Required]
        [Display(Name = "Problems Experienced(If any)")]
        public string ProblemsDay03 { get; set; }
        [Display(Name = "General Comments:")]

        //[Required]
        public string CommentsDay03 { get; set; }

        //Day 4 Thursday

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please verify Fridays's Date")]
        [Display(Name = "Thursday's Date:")]
        [DisplayFormat(DataFormatString = "{0:DD-MM-YYYY}", ApplyFormatInEditMode = true)]
        public DateTime? Day04 { get; set; }

        [Required]
        [Display(Name = "Task Completed:")]
        public string TaskDay04 { get; set; }


        [Required(ErrorMessage = "Please ignore unless incorrect")]
        [Display(Name = "Completed(Satisfaction)?:")]
        public string CompletedSatDay04 { get; set; }


        [Required(ErrorMessage = "Please ignore unless incorrect")]
        [Display(Name = "Time Taken(Hours):")]
        public string TimeTakenDay04 { get; set; }


        //[Required]
        [Display(Name = "Problems Experienced(If any)")]
        public string ProblemsDay04 { get; set; }
        [Display(Name = "General Comments:")]

        //[Required]
        public string CommentsDay04 { get; set; }

        //Day 5 Friday

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Friday's Date:")]
        [DisplayFormat(DataFormatString = "{0:DD-MM-YYYY}", ApplyFormatInEditMode = true)]
        public DateTime? Day05 { get; set; }

        [Required]
        [Display(Name = "Task Completed:")]
        public string TaskDay05 { get; set; }


        [Required(ErrorMessage = "Please ignore unless incorrect")]
        [Display(Name = "Completed(Satisfaction)?:")]
        public string CompletedSatDay05 { get; set; }


        [Required(ErrorMessage = "Please ignore unless incorrect")]
        [Display(Name = "Time Taken(Hours):")]
        public string TimeTakenDay05 { get; set; }


        //[Required]
        [Display(Name = "Problems Experienced(If any)")]
        public string ProblemsDay05 { get; set; }
        [Display(Name = "General Comments:")]

        //[Required]
        public string CommentsDay05 { get; set; }




        [Required]
        [Display(Name = "Learner's Signature:")]
        public string LearnerSignature { get; set; }

        [Display(Name = "Signature FontSyle")]
        public string fontStyle { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please ignore unless incorrect")]
        [Display(Name = "Date Learner Signed:")]
        [DisplayFormat(DataFormatString = "{0:DD-MM-YYYY}", ApplyFormatInEditMode = true)]
        public DateTime? DateLearnerSigned { get; set; }


        // Allow preview
        [Display(Name = "Would you like to preview your Logbook? (Tick if YES)")]
        public string Preview { get; set; }


    }
}