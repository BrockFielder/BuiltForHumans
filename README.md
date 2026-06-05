# Built For Humans

Portfolio and marketing site for **Built For Humans (BFH)**, a small architecture firm.

## Stack
- **Backend:** ASP.NET Core MVC (.NET 10)
- **Data:** EF Core + PostgreSQL
- **Frontend:** Razor views, TypeScript, CSS
- **Email:** SendGrid (contact form)
- **Deployment (planned):** Docker, Kubernetes on AWS

## Features
- Project portfolio with images, tags, and filtering
- Team page with member bios
- About page
- Contact form: emails the firm's mailbox, with a DB row kept as a backup log

## Status
Work in progress. Domain model and service/controller layers are in place;
database wiring, Razor views, and deployment are the next steps.
