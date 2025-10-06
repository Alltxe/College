// src/movies/dto/create-movie.dto.ts
import {
  IsString,
  IsNumber,
  Min,
  Max,
  Length,
  Matches,
  IsDateString,
} from 'class-validator';
import { ApiProperty } from '@nestjs/swagger';

export class CreateMovieDto {
  @ApiProperty({ description: 'Название фильма', minLength: 3, maxLength: 60 })
  @Length(3, 60, { message: 'Заголовок должен содержать от 3 до 60 символов.' })
  @IsString({ message: 'Заголовок должен быть строкой.' })
  title: string;

  @ApiProperty({ description: 'Дата выпуска в формате YYYY-MM-DD', example: '2023-01-01' })
  @IsDateString(
    { strict: true },
    { message: 'Дата выпуска должна быть в формате YYYY-MM-DD.' },
  )
  releaseDate: string;

  @ApiProperty({ description: 'Цена фильма', minimum: 1, maximum: 100 })
  @Min(1, { message: 'Цена должна быть не менее 1.' })
  @Max(100, { message: 'Цена должна быть не более 100.' })
  @IsNumber({}, { message: 'Цена должна быть числом.' })
  price: number;

  @ApiProperty({ description: 'Жанр фильма', maxLength: 30 })
  @Length(1, 30, { message: 'Жанр должен содержать до 30 символов.' })
  @Matches(/^[A-Z]+[a-zA-Z\s-]*$/, { message: 'Некорректный формат жанра.' })
  @IsString({ message: 'Жанр должен быть строкой.' })
  genre: string;

  @ApiProperty({ description: 'Рейтинг фильма', maxLength: 5 })
  @Length(1, 5, { message: 'Рейтинг должен содержать до 5 символов.' })
  @Matches(/^[A-Z]+[a-zA-Z0-9\s-]*$/, {
    message: 'Некорректный формат рейтинга.',
  })
  @IsString({ message: 'Рейтинг должен быть строкой.' })
  rating: string;
}
