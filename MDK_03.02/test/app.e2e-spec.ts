import { Test, TestingModule } from '@nestjs/testing';
import { INestApplication, ValidationPipe } from '@nestjs/common';
import request from 'supertest';
import { App } from 'supertest/types';
import { AppModule } from './../src/app.module';

describe('AppController (e2e)', () => {
  let app: INestApplication<App>;

  beforeEach(async () => {
    const moduleFixture: TestingModule = await Test.createTestingModule({
      imports: [AppModule],
    }).compile();

    app = moduleFixture.createNestApplication();
    app.useGlobalPipes(new ValidationPipe({
      transform: true,
      whitelist: true,
      forbidNonWhitelisted: true
    }));
    await app.init();
  });

  it('/ (GET)', () => {
    return request(app.getHttpServer())
      .get('/')
      .expect(200)
      .expect('Hello World!');
  });

  it('/movies (POST) - success', () => {
    const createMovieDto = {
      title: 'Test Movie',
      releaseDate: '2023-01-01',
      price: 10,
      genre: 'Action',
      rating: 'PG-13',
    };
    return request(app.getHttpServer())
      .post('/movies')
      .send(createMovieDto)
      .expect(201)
      .expect(createMovieDto);
  });

  it('/movies (POST) - validation error', () => {
    const invalidDto = {
      title: 'Te',
      releaseDate: 'invalid-date',
      price: 150,
      genre: 'action',
      rating: 'PG-13',
    };
    return request(app.getHttpServer())
      .post('/movies')
      .send(invalidDto)
      .expect(400);
  });
});
