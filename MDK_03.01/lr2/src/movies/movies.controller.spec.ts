import { Test, TestingModule } from '@nestjs/testing';
import { MoviesController } from './movies.controller';
import { MoviesService } from './movies.service';

describe('MoviesController', () => {
  let controller: MoviesController;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      controllers: [MoviesController],
      providers: [MoviesService],
    }).compile();

    controller = module.get<MoviesController>(MoviesController);
  });

  it('should be defined', () => {
    expect(controller).toBeDefined();
  });

  it('should create a movie', () => {
    const createMovieDto = {
      title: 'Test Movie',
      releaseDate: '2023-01-01',
      price: 10,
      genre: 'Action',
      rating: 'PG-13',
    };
    expect(controller.create(createMovieDto)).toEqual(createMovieDto);
  });
});
