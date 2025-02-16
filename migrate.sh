echo "Running database migrations..."


until dotnet ef database update --connection "Server=db,1433;Database=HakiosDB;User=sa;Password=StrongPassword123;TrustServerCertificate=True"; do
  echo "Waiting for database to be ready..."
  sleep 5
done

echo "Database migration completed."
exit 0

