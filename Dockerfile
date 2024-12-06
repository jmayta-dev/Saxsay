# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/mssql/server:2022-latest

# Switch to root to install fulltext
USER root
# Install dependencies
RUN apt-get update
RUN apt-get install -yq gnupg gnupg2 gnupg1 curl apt-transport-https
# Install SQL Server package links
RUN curl https://packages.microsoft.com/keys/microsoft.asc -o /var/opt/mssql/ms-key.cer
RUN apt-key add /var/opt/mssql/ms-key.cer
RUN curl https://packages.microsoft.com/config/ubuntu/22.04/mssql-server-2022.list -o /etc/apt/sources.list.d/mssql-server-2022.list
RUN apt-get update
# Install SQL Server full-text-search
RUN apt-get install -y mssql-server-fts

# Cleanup
RUN apt-get clean
RUN rm -rf /var/lib/apt/lists

# Run SQL Server process
ENTRYPOINT [ "/opt/mssql/bin/sqlservr" ]