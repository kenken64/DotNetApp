from ubuntu:latest

WORKDIR backend-svr

RUN apt-get update && \
    apt-get install -y software-properties-common && \
    apt-get install -y wget && \
    rm -rf /var/lib/apt/lists/*

RUN wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb

RUN dpkg -i packages-microsoft-prod.deb

RUN add-apt-repository universe

RUN apt install apt-transport-https -y

RUN apt-get update

RUN apt install dotnet-sdk-3.0 -y

COPY ./ ./

RUN dotnet restore

RUN dotnet build

EXPOSE 5000:5000

CMD [ "dotnet", "run" ]