.PHONY: run-local
run-local:
	@echo "Running local server";
	# dotnet watch run;

.PHONY: migrate-build
migrate-add:
	@read -p "Enter migration name: " name; \
	dotnet ef migrations add $$name -o Migrations/

.PHONY: migrate-db
migrate-db:
	@echo "Migrating Database";
	dotnet ef database update
