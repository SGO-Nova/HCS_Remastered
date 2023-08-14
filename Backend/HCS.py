from flask import *
import pymongo
import json, time

app = Flask(__name__)

APP_NAME = "HCS: Remastered"
MONGODB = "mongodb://127.0.0.1:27017/"

try:
    mongo_client = pymongo.MongoClient(MONGODB)
    db = mongo_client["Mercy_Hospital"]
except Exception as exception:
    print(exception)
    raise exception

@app.route("/", methods=["GET"])
def home_page():
    data_set = {
        "App": APP_NAME,
        "Time": time.time()
    }
    json_dump = json.dumps(data_set)

    return json_dump

@app.route("/Employees/Login", methods=["GET"])
def login():
    _id = request.args.get("id")

    return f"GOT \n\tID: {_id}\n"

@app.route("/Employees/Create", methods=["POST"])
def create():
    _id = request.args.get("id")
    _password = request.args.get("password")

    return f"GOT \n\tID: {_id}\n\tPassword: {_password}\n"

if __name__ == "__main__":
    app.run(port=7777)