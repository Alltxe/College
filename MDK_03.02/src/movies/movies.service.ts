import { Injectable } from '@nestjs/common';
import { CreateMovieDto } from './dto/create-movie.dto';

@Injectable()
export class MoviesService {
  create(createMovieDto: CreateMovieDto) {
    // Минимальная логика: просто возвращаем DTO для проверки
    return createMovieDto;
  }
}
