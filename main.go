package main

import (
	"bytes"
	"fmt"
	"io"
	"log"
	"net/http"
	"os"
	"strings"
)

// Approach to file taken from https://stackoverflow.com/a/40699578/6674421
func handler(w http.ResponseWriter, r *http.Request) {
	log.Print("transcription: received a request")

	r.ParseMultipartForm(32 << 20) // limit your max input length!
	file, header, err := r.FormFile("file")
	if err != nil {
		panic(err)
	}
	defer file.Close()

	name := strings.Split(header.Filename, ".")
	fmt.Printf("File name %s\n", name[0])

	var buf bytes.Buffer
	io.Copy(&buf, file)
	result, err := Recognize(buf.Bytes())
	buf.Reset()

	if err != nil {
		http.Error(w, err.Error(), 500)
		return
	}
	fmt.Fprintf(w, "%s\n", result)
	return
}

func main() {
	log.Print("helloworld: starting server...")

	http.HandleFunc("/", handler)

	port := os.Getenv("PORT")
	if port == "" {
		port = "8080"
	}

	log.Printf("helloworld: listening on port %s", port)
	log.Fatal(http.ListenAndServe(fmt.Sprintf(":%s", port), nil))
}
