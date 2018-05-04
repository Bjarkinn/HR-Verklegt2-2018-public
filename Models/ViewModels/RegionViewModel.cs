namespace TheBookCave.Models.ViewModels {
    public class RegionViewModel {
        public int Id { get; set; }
        // Name of Region.
        public string Name { get; set; }
        // path to Country that region represents.
        public string CountryId { get; set; }

    }
}