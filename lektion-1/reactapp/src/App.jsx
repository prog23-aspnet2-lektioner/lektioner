import React, { useState } from 'react'
import './App.css'

function App() {
  const [email, setEmail] = useState('')
  const [message, setMessage] = useState('')

  const handleSubscribe = async (e) => {
    e.preventDefault()
    setMessage('')

    const res = await fetch(`https://localhost:7224/api/subscribers`, { 
      method: 'post',
      headers: {
        'content-type': 'application/json'
      },
      body: JSON.stringify({email: email}) 
    })

    if (res.status === 200)
      setMessage('You are subscribed')
    else
      setMessage('Unable to subscribe')

    setEmail('')
  }

  return (
    <div className="container mt-4">
      <h5>Subscribe Now!</h5>
      <form onSubmit={handleSubscribe} className="d-flex gap-3 col-5">
        <input value={email} onChange={(e) => setEmail(e.target.value)} className="form-control" type="email" placeholder="Enter your email" />
        <button type="submit" className="btn btn-secondary">Subscribe</button>
      </form>
      <div className="mt-2 text-muted small">{message}</div>
    </div>
  )
}

export default App
