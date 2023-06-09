import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";

function DeleteConfirmation(props) {
  return (
    <>
      <Modal
        show={props.showModal}
        onHide={() => {
          props.closePopup();
        }}
      >
        <Modal.Header closeButton>
          <Modal.Title>{props.title}</Modal.Title>
        </Modal.Header>
        <Modal.Body>{props.body}</Modal.Body>
        <Modal.Footer>
          <Button
            variant="secondary"
            onClick={() => {
              props.closePopup();
            }}
          >
            Close
          </Button>
          <Button
            variant="danger"
            onClick={() => {
              props.deleteConfirmHandler();
            }}
          >
            Confirm Delete
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default DeleteConfirmation;
