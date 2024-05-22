import React, { useState } from 'react'
import Arrows from '../../assets/images/arrows.svg'

const Subscribe = () => {
    const [subscribeForm, setSubscribeForm] = useState({
        email: '',
        dailyNewsletter: false,
        advertisingUpdates: false,
        weekInReview: false,
        eventUpdates: false,
        startupsWeekly: false,
        podcasts: false,
    })
    const [statusMessage, setStatusMessage] = useState("* Yes, I accept the user terms and privacy policy.")

    const handleOnChange = (e) => {
        const { name, value, type, checked } = e.target;
        console.log(name)
        const newValue = type === 'checkbox' ? checked : value;
        setSubscribeForm((current) => ({ ...current, [name]: newValue }));
    }

    const handleSubscribeSubmit = async (e) => {
        e.preventDefault()

        const res = await fetch('http://localhost:5240/api/subscribe', {
            method: 'post',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(subscribeForm)
        })

        if (res.status === 200)
            setStatusMessage('You are now subscribed')
    }

  return (
    <section className="subscribe">
        <div className="container">
            <div className="title">
                <h1>Don't Want to Miss Anything?</h1>
                <img src={Arrows} alt="arrows" />
            </div>
            <form onSubmit={handleSubscribeSubmit}>
                <div className="subscribe-options">
                    <h5>Sign up for Newsletters</h5>
                    <div className="options">
                        <div className="checkbox-group">
                            <input name="dailyNewsletter" checked={subscribeForm.dailyNewsletter} onChange={handleOnChange} type="checkbox" />
                            <label htmlFor="">Daily Newsletter</label>
                        </div>
                        <div className="checkbox-group">
                            <input name="advertisingUpdates" checked={subscribeForm.advertisingUpdates} onChange={handleOnChange} type="checkbox" />
                            <label htmlFor="">Advertising Updates</label>
                        </div>
                        <div className="checkbox-group">
                            <input name="weekInReview" checked={subscribeForm.weekInReview} onChange={handleOnChange} type="checkbox" />
                            <label htmlFor="">Week in Review</label>
                        </div>
                        <div className="checkbox-group">
                            <input name="eventUpdates" checked={subscribeForm.eventUpdates} onChange={handleOnChange} type="checkbox" />
                            <label htmlFor="">Event Updates</label>
                        </div>
                        <div className="checkbox-group">
                            <input name="startupsWeekly" checked={subscribeForm.startupsWeekly} onChange={handleOnChange} type="checkbox" />
                            <label htmlFor="">Startups Weekly</label>
                        </div>
                        <div className="checkbox-group">
                            <input name="podcasts" checked={subscribeForm.podcasts} onChange={handleOnChange} type="checkbox" />
                            <label htmlFor="">Podcasts</label>
                        </div>
                    </div>
                </div>
                <div className="subscribe-email">
                    <i className="fa-regular fa-envelope"></i>
                    <input name="email" value={subscribeForm.email} onChange={handleOnChange} className="form-input" type="email" placeholder="Enter your email" />
                    <button className="btn btn-theme" type="submit">Subscribe*</button>
                </div>
                <p>{statusMessage}</p>
            </form>

        </div>
    </section>
  )
}

export default Subscribe