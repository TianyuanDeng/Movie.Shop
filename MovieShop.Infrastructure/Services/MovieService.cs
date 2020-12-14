using MovieShop.Core.Entities;
using MovieShop.Core.Models.Request;
using MovieShop.Core.Models.Response;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using MovieShop.Infrastructure.Data;
using MovieShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace MovieShop.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        private readonly IAsyncRepository<MovieGenre> _asyncRepository;

        //Constructor Injection
        //DI is pattern that enables us to write loosely coupled code so that code is more matinable 
        public MovieService(IMovieRepository repository, IAsyncRepository<MovieGenre> asyncRepository)
        {
            // create MovieRepo instance in every method in my service class
            // newing up is very convineint but we need to avoid it as much as we can
            // make sure you dont break any existing code....
            // always go back do the regression testing...
            //  _repository = new MovieRepository(new MovieShopDbContext(null));
            _repository = repository;
            _asyncRepository = asyncRepository;
        }


        public async Task<IEnumerable<MovieResponseModel>> GetTopRevenueMovies()
        {
            var movies = await _repository.GetHighestRevenueMovies();
            
            //Map our Movie Entity to MovieResponseModel
            var movieResponseModel = new List<MovieResponseModel>();
            foreach (var movie in movies)
            {
                movieResponseModel.Add(new MovieResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    ReleaseDate = movie.ReleaseDate.Value,
                    Title = movie.Title
                });

            }

            return movieResponseModel;
        }

        public async Task<MovieResponseModel> GetMoveById(int id)
        {
            var movie = await _repository.GetMovieById(id);
            var model = new MovieResponseModel
            {
                Id = movie.Id,
                PosterUrl = movie.PosterUrl,
                ReleaseDate = movie.ReleaseDate.Value,
                Title = movie.Title
            };

            return model; 
        }

        //public override async Task<Movie> GetByIdAsync(int id)
        //{
        //    var movie = await _dbContext.Movies
        //                                .Include(m => m.MovieCasts).ThenInclude(m => m.Cast).Include(m => m.MovieGenres)
        //                                .ThenInclude(m => m.Genre)
        //                                .FirstOrDefaultAsync(m => m.Id == id);
        //    if (movie == null) return null;
        //    var movieRating = await _dbContext.Reviews.Where(r => r.MovieId == id).DefaultIfEmpty()
        //                                      .AverageAsync(r => r == null ? 0 : r.Rating);
        //    if (movieRating > 0) movie.Rating = movieRating;
        //    return movie;
        //}

        public async Task<IEnumerable<MovieResponseModel>> GetTopRatedMovies()
        {
            var movies = await _repository.GetTopRatedMovies();

            return movies;
        }

        public async Task<IEnumerable<MovieResponseModel>> GetMoviesByGenre(int genreId)
        {
            var movies = await _repository.GetMoviesByGenre(genreId);

            return movies;
        }

        public async Task<MovieDetailsResponseModel> CreateMovie(MovieCreateRequest movieCreateRequest)
        {
            //var movie = new Movie{ 
            //    Title = movieCreateRequest.Title,
            //    Overview = movieCreateRequest.Overview,
            //    Tagline = movieCreateRequest.Tagline,
            //    Revenue = movieCreateRequest.Revenue,
            //    Budget = movieCreateRequest.Budget,
            //    ImdbUrl = movieCreateRequest.ImdbUrl,
            //    TmdbUrl = movieCreateRequest.TmdbUrl,
            //    PosterUrl = movieCreateRequest.PosterUrl,
            //    BackdropUrl = movieCreateRequest.BackdropUrl,
            //    OriginalLanguage = movieCreateRequest.OriginalLanguage,
            //    ReleaseDate = movieCreateRequest.ReleaseDate,
            //    Price = movieCreateRequest.Price
            //};

            //var createdMovie = await _repository.AddAsync(movie);

            //foreach (var genre in movieCreateRequest.Genres)
            //{
            //    var movieGenre = new MovieGenre
            //    {
            //        MovieId = createdMovie.Id,
            //        GenreId = genre.Id
            //    };

            //    await _asyncRepository.AddAsync(movieGenre);
            //}

            //var responseModel = new MovieDetailsResponseModel
            //{
            //    Title = movieCreateRequest.Title,
            //    Overview = movieCreateRequest.Overview,
            //    Tagline = movieCreateRequest.Tagline,
            //    Revenue = movieCreateRequest.Revenue,
            //    Budget = movieCreateRequest.Budget,
            //    ImdbUrl = movieCreateRequest.ImdbUrl,
            //    TmdbUrl = movieCreateRequest.TmdbUrl,
            //    PosterUrl = movieCreateRequest.PosterUrl,
            //    BackdropUrl = movieCreateRequest.BackdropUrl,
            //    ReleaseDate = movieCreateRequest.ReleaseDate,
            //    Price = movieCreateRequest.Price,
            //    Genres = movieCreateRequest.Genres
            //};

            //return responseModel;

            throw new NotImplementedException();
        }
    }
}
