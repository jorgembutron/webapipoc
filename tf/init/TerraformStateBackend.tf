
variable "region" {
  default = "us-east-1"
}

provider "aws" {
  region = var.region
}

resource "aws_s3_bucket" "malicious-s3" {
  bucket = "malicious-s3"
  
  tags = {
    "Type" = "SteteFile"
  }
}

resource "aws_s3_bucket_object" "myStateFile" {
    bucket = aws_s3_bucket.malicious-s3.bucket
    
    key = "dev/"
}
