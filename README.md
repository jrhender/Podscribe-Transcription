This is podscribe! A project to enable transcription of podcasts.
For vision blog post, see [https://site.j-henderson.com/blog/Podscribe:%20Vision]

Steps to use in development:
1. Config that service account key is set: `export GOOGLE_APPLICATION_CREDENTIALS="[PATH]"`

Hosted service using Google Cloud Run. [Cloud Run Quick Start](https://cloud.google.com/run/docs/quickstarts/build-and-deploy)
Steps to deploy:
1. Confirm that gcloud config is correct (authenticated and pointing to correct project)
2. Get Google Cloud project ID: `gcloud config get-value project`
3. Build container image: `gcloud builds submit --tag gcr.io/PROJECT-ID/transcription`
4. Deploy: `gcloud run deploy --image gcr.io/PROJECT-ID/transcription --platform managed`

Can be called in dev by `curl http://localhost:8080 -F "file=@EPISODE61_CUT.mp3" -v`

Instructions on how to use Google Speech-to-Text .Net library:
https://cloud.google.com/speech-to-text/docs/quickstart-client-libraries?hl=sl
https://googleapis.github.io/google-cloud-dotnet/docs/Google.Cloud.Speech.V1/index.html 