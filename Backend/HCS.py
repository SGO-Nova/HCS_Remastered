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

#Employee
@app.route("/Employees/Login", methods=["GET"])
def login():
    _id = request.args.get("id")

    print(f"ID: {_id}")

    employee = db["Employees"].find({
        "id": int(_id)
    },
    {
        "_id": False
    })

    print("Employee:")
    for x in employee:
        print(x)
        return str(x)

    return None

@app.route("/Employees/Create", methods=["POST"])
def create():
    _id = request.args.get("id")
    _password = request.args.get("password")
    _type = requests.args.get("type")
    
    db["Employees"].insert_one({
        "id": _id,
        "password": _password,
        "type": _type
    })

    return _id

if __name__ == "__main__":
    app.run(port=7777)