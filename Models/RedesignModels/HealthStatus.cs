using System.ComponentModel.DataAnnotations.Schema;

namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class HealthStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HealthStatusID { get; set; } 
        public string Name { get; set; }        
        // dabo magamit sa m na masterlist so masterlist is collection
        public ICollection<Masterlist> Masterlists { get; set; }
    }
}