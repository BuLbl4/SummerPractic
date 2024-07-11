import React, { useState } from "react";
import axiosClient from "../../utils/axiosClient";
import QuestionForm from "../Course/CourseDetail/QuestionForm";

const AddNewCourseUser = ({ userInfo }) => {
    const [success, setSuccess] = useState(false);
    const [formData, setFormData] = useState({
        name: '',
        description: '',
        count: 1, // Добавляем count в состояние формы
    });

    const [showQuestionForm, setShowQuestionForm] = useState(false);
    const [formCount, setFormCount] = useState(1);
    const [test, setTest] = useState("");

    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setFormData({
            ...formData,
            [name]: type === 'checkbox' ? checked : value
        });
        if (name === 'count') {
            setFormCount(parseInt(value));
        }
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axiosClient.post('Test/CreateTest', {
                title: formData.name,
                description: formData.description,
            });
            if (response.data.isSuccessfully) {
                setTest(response.data.message);
                setSuccess(true);
            } else {
                alert("Failed to add test");
            }
        } catch (error) {
            console.error('Error adding course!', error);
        }
    };

    const handleShowQuestionForm = () => {
        setShowQuestionForm(true);
    };

    const handleClearQuestions = () => {
        setShowQuestionForm(false);
        setFormCount(1);
    };

    return (
        <div className="col-lg-9 col-md-9 col-sm-12">
            <div className="row">
                <div className="col-xl-12 col-lg-12 col-md-12">
                    <div className="dashboard_wrap">
                        <div className="form_blocs_wrap">
                            <form onSubmit={handleSubmit}>
                                <div className="row justify-content-between">
                                    <div className="col-xl-9 col-lg-8 col-md-7 col-sm-12">
                                        <div className="tab-content" id="v-pills-tabContent">
                                            <div className="tab-pane fade show active"
                                                 id="v-pills-basic" role="tabpanel"
                                                 aria-labelledby="v-pills-basic-tab">
                                                <div className="form-group smalls">
                                                    <label>Name*</label>
                                                    <input type="text" name="name" className="form-control"
                                                           placeholder="Enter Course Name" onChange={handleChange}
                                                           value={formData.name} required />
                                                </div>
                                                <div className="form-group smalls">
                                                    <label>Description*</label><br />
                                                    <textarea className="summernote" name="description"
                                                              style={{ width: 600 }} onChange={handleChange}
                                                              value={formData.description} required></textarea>
                                                </div>
                                                <div className="form-group smalls">
                                                    <label>Count</label>
                                                    <input type="number" name="count" className="form-control"
                                                           placeholder="Count" onChange={handleChange}
                                                           value={formData.count} required />
                                                </div>
                                            </div>
                                            <div className="form-group smalls">
                                                <button type="submit" className="btn theme-bg text-white">Save Changes
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </form>
                            {success && !showQuestionForm &&
                                <div className="succ_wrap">
                                    <div className="succ_121"><i className="fas fa-thumbs-up"></i></div>
                                    <div className="succ_122">
                                        <h4>Test Successfully Added</h4>
                                        <p>The course has been successfully added.</p>
                                    </div>
                                    <div className="succ_123">
                                        <button className="btn theme-bg text-white" onClick={handleShowQuestionForm}>Add Questions</button>
                                    </div>
                                </div>
                            }
                            {showQuestionForm &&
                                <div>
                                    {[...Array(formCount)].map((_, index) => (
                                        <div key={index} className="form_blocs_wrap">
                                            <QuestionForm courseId={test} />
                                        </div>
                                    ))}
                                    <button className="btn btn-danger" onClick={handleClearQuestions}>Clear Questions</button>
                                </div>
                            }
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default AddNewCourseUser;
