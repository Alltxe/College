import os
import psycopg2
from dotenv import load_dotenv

load_dotenv(os.path.join(os.path.dirname(__file__), "..", ".env"))


def get_connection():
    return psycopg2.connect(
        host=os.getenv("APP_DB_HOST", "localhost"),
        port=int(os.getenv("APP_DB_PORT", 5432)),
        dbname=os.getenv("APP_DB_NAME"),
        user=os.getenv("APP_DB_USER"),
        password=os.getenv("APP_DB_PASSWORD"),
    )
