# gne
### Graphviz Network Explorer _(GNE)_, simple user interface for interacting with svg output files from Graphviz.

> Graphviz is capable of creating highly detailed network diagrams that can turn complicated to
> read, interpret and, thus, getting insight from.

This project aims at leveraging the capabilities of modern data visualition to facilitate the task
of network exploration with a few key questions in mind:
- __What different nodes are there for each type of address range?__
- __Is there a trend in communication between nodes of different address range?__
- __Which are the different nodes that connect to a specific one and, how are ports involved?__

For this, GNE takes a Graphviz svg output file as input along with the graph xpath specification
needed to identify between nodes and links.

## About this repository
This repository holds the code for the conversion API server that performs the parsing and JSON-formatting
of networks rendered as SVG images using Graphviz.

The server is implemented using [ASP.Net Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1),
using the Kestrel server multiplatform implementation.

This same repository has both the project and the [Visual Studio](https://visualstudio.microsoft.com/) solution for the API server; therefore, you
may clone the repository directly through Vsual Studio and work with it.

### Endpoints
- `/health`: Health status JSON response.

## How to run it
Visual Studio allows executing this docker-ready project directly within the IDE if you have the Docker
environment already setted up in your computer. This is the easiest _and recomended way for development_.

If you just want to run the server:
- You can download the latset build from [releases](https://github.com/Janchorizo/gne-conversion-api/releases) and execute in your computer using `[some command]`,
- or download the latest docker build for the [janchorizo/gneconversionapi](https://hub.docker.com/r/janchorizo/gneconversionapi) repo in Dockerhub and run the server using `docker run -p <host port>:80 janchorizo/gneconversionapi`.
