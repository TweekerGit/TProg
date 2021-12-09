pipeline {
		options {timestamps()}
		
		agent none
		stages {
			stage('Check scm'){
				agent any
				steps{
					checkout scm
				}
			}
			stage('Build'){
				steps{
					echo "Building ${BUILD_NUMBER}"
					sh "dotnet build"
					echo "Build completed"
				}
			}
			stage('Test'){
				agent{docker {image 'dotnetapp'
						args '-u=\"root\"'
						}
					}
				steps{
					sh "dotnet ElementarySchool.Web.dll"
				}
				post{
					success{
						echo "Application compleated"
					}
					failure{
						echo "Error"
					}
				}
			}
		}

	}
