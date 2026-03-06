using SQLite;

namespace MigraineTracker.Models
{
    [Table("migraines")]          // nom de la table dans le fichier SQLite
    public class Migraine
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }         // généré automatiquement : 1, 2, 3...

        [NotNull]
        public DateTime StartTime { get; set; }  // heure de début, obligatoire

        public DateTime? EndTime { get; set; }

        [NotNull]
        public DateTime CreatedAt { get; set; }

        [NotNull]
        public int Intensity { get; set; }

        public string ProbableCause { get; set; } = string.Empty;
        public string SymptomsBefore { get; set; } = string.Empty;
        public string SymptomsDuring { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;


    }
}