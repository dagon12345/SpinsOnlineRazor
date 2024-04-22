using System.ComponentModel.DataAnnotations.Schema;


namespace SpinsOnlineRazor.Models.RedesignModels.ComplexModels
{
    public class Assessment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AssessmentID { get; set; }
        public string Name { get; set; }

        //Dabo na validation mugamit sa m
        public ICollection<Validationform> Validationforms { get; set; }
    }
}